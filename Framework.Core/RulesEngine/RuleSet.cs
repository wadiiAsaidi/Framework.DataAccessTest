using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IRuleSet<TIn, TOut> : IActivity<TIn, TOut>
    {
        IList<IRuleRunDefinition<TIn, TOut>> RuleRunDefinitions { get; }
        Func<TOut, TOut, TOut> AggregateFunction { get; }
        void Configure();

    }
    public interface IRuleOperations<out TIn, in TOut>
    {
        IAfterDoRuleOperations<TIn, TOut> Do<IRule>() where IRule : IActivity<TIn, TOut>, new();
    }
    public interface IAfterDoRuleOperations<out TIn, in TOut>
    {
        void BreakIfMatched();
    }
    public abstract class RuleSet<TIn, TOut> : Activity<TIn, TOut>, IRuleOperations<TIn, TOut>, IRuleSet<TIn, TOut>, IAfterDoRuleOperations<TIn, TOut>
    {
        protected RuleSet()
        {
            this.RuleRunDefinitions = new List<IRuleRunDefinition<TIn, TOut>>();
            Configure();
        }

        public IList<IRuleRunDefinition<TIn, TOut>> RuleRunDefinitions { get; private set; }

        public abstract Func<TOut, TOut, TOut> AggregateFunction { get; }

        public abstract AggregationMode AggregationMode { get; }

        public IRuleRunDefinition<TIn, TOut> CurrentRule { get; set; }


        public void Configure()
        {
            this.OnConfigure();
        }
        public override sealed TOut OnRun(TIn input)
        {
            throw new NotImplementedException();
        }
        public override sealed IRunResult<TOut> Run(TIn input, Action<IRunResult<TOut>> evaluatedCallbackAction = null)
        {
            var isMatched = this.IsMatched(input);
            Exception error = null;
            try
            {
                if (!isMatched.HasValue || isMatched.Value)
                {
                    var result = InternalRunRules(input, evaluatedCallbackAction);
                    return result;
                }

                return new MultipleRunResult<TOut>()
                {
                    Result = default(TOut),
                    Rule = this,
                    SingleRunResults = new List<MultipleRunResult<TOut>>()
                };
            }
            catch (Exception ex)
            {
                error = ex;
                throw;
            }
            finally
            {
                if (error != null)
                {
                    OnFailed(input);
                }
            }
        }

        public IAfterDoRuleOperations<TIn, TOut> Do<TRule>() where TRule : IActivity<TIn, TOut>, new()
        {
            var ruleRunDefinition = GetActivityRuleRunDefinition<TRule>();
            return Do(ruleRunDefinition);
        }

        protected abstract void OnConfigure();

        protected virtual void OnFailed(TIn input)
        {
        }



        private static RuleRunDefinition<TIn, TOut> GetActivityRuleRunDefinition<TRule>()
            where TRule : IActivity<TIn, TOut>, new()
        {
            var rule = new TRule();

            return InternalGetActivityRuleRunDefinition(rule);
        }

        private static RuleRunDefinition<TIn, TOut> InternalGetActivityRuleRunDefinition<TRule>(TRule rule)
            where TRule : IActivity<TIn, TOut>, new()
        {
            var ruleRunDefinition = new RuleRunDefinition<TIn, TOut>
            {
                Rule = rule
            };

            return ruleRunDefinition;
        }

        private IAfterDoRuleOperations<TIn, TOut> Do(IRuleRunDefinition<TIn, TOut> ruleRunDefinition)
        {
            ruleRunDefinition.Break = false;

            this.RuleRunDefinitions.Add(ruleRunDefinition);
            this.CurrentRule = ruleRunDefinition;
            return this;
        }

        private MultipleRunResult<TOut> InternalRunRules(TIn target, Action<IRunResult<TOut>> evaluatedCallbackAction = null)
        {
            var evaluationResults = new List<IRunResult<TOut>>();
            var mustBreak = false;

            //var shouldBreakOnError = errorHandlingMode != ActivityErrorHandlingMode.ContinueOnError;

            foreach (var ruleDef in this.RuleRunDefinitions.Where(ruleDef => ruleDef.Rule != null))
            {
                var evaluationResult = ruleDef.Rule.Run(target);

                evaluatedCallbackAction?.Invoke(evaluationResult);

                //var hasError = evaluationResult?.Error != null;
                var @break = ruleDef.Break && evaluationResult.IsMatched == ruleDef.BreakOnMatched;
                //mustBreak = (shouldBreakOnError && hasError) || @break;

                evaluationResults.Add(evaluationResult);

                if (mustBreak)
                {
                    break;
                }
            }

            var finalResult = evaluationResults.Select(u => u.Result)
                                            .Aggregate(this.AggregateFunction);


            //var errors = evaluationResults.Where(r => r.Error != null).Select(r => r.Error);
            //var error = errors.FirstOrDefault();

            //if (!shouldBreakOnError && errors.Any())
            //{
            //    error = new AggregateException(errors);
            //}

            var result = new MultipleRunResult<TOut>
            {
                Result = finalResult,
                SingleRunResults = evaluationResults,
                Rule = this,
                //Error = error
            };

            return result;
        }

        void IAfterDoRuleOperations<TIn, TOut>.BreakIfMatched()
        {
            this.CurrentRule.Break = true;
            this.CurrentRule.BreakOnMatched = true;
            this.CurrentRule = null;
        }
    }

    public enum AggregationMode
    {
        And = 0,
        Or = 1
    }
}
