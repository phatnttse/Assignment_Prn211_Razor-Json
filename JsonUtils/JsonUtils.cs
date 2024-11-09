namespace JsonUtils
{
    public static class JsonUtils
    {
        public static string ReadJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return string.Empty;
            }

            return File.ReadAllText(filePath);
        }
    }
}
