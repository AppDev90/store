

namespace Store.Infrastructure.Utility
{
    public static class UniqueCodeGenerator
    {
        public static string GenerateBasketId()
        {
            return SequentialGuidGenerator.NewSequentialGuid()
                .ToString();
        }
    }
}
