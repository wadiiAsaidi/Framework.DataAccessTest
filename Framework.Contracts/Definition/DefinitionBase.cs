using Framework.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.Contracts.DataAnnotation;
using System.Net.Http.Headers;

namespace Framework.Contracts.DataMappers
{
    public abstract class DefinitionBase
    {
        public DefinitionBase()
        {
            this.Configure();
        }
        public virtual void Configure()
        {
            this.OnConfigure();
            this.PreConfigure();
        }

        public abstract void OnConfigure();
        public abstract void PreConfigure();

        public IList<DefinictionItem> Definictions = new List<DefinictionItem>();

        public Dictionary<string, IList<DefinictionItem>> DictDefinictions = new Dictionary<string, IList<DefinictionItem>>();

        public abstract string FileGeneratedName { get; }
    }

    public abstract class DefinitionBase<TClass> : DefinitionBase where TClass : class, new()
    {
        protected abstract Type BaseType { get; set; }
        public abstract Annotation AddProperty(Expression<Func<TClass, object>> expression);
    }

    public abstract class Definition<TClass> : DefinitionBase<TClass> where TClass : class, new()
    {

        public override Annotation AddProperty(Expression<Func<TClass, object>> expression)
        {

            return new Annotation();
        }
    }
}
