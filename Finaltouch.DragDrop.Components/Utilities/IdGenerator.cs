namespace Finaltouch.DragDrop.Components.Utilities
{
    public static class IdGenerator
    {
        public static string GetId(int length)
        {
            if (length < 4 || length > 32)
            {
                throw new ArgumentException("Unique Id length must be between 4 and 32 characters.");
            }
            string base64 = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            base64 = base64.Replace("/", "_");
            base64 = base64.Replace("+", "-");
            return base64[..length];
        }
    }
}
