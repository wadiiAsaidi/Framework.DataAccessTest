using Framework.Contracts.Data;


namespace Framework.Contracts.DataMappers
{
    public abstract class AddDtoDefinition<TDto> : DtoDefinition<TDto> where TDto : class, new()
    {

        public override void PreConfigure()
        {
            
        }

        public override void OnConfigure()
        {

        }
    }
}
