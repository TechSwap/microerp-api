namespace VibeDigita.Domain.Utilities
{
    public class Utilities
    {
        public static byte[]? CreateFile(string filePath)
        {
            byte[] file = null;

            string directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string extensao = Path.GetExtension(filePath);

            if (!File.Exists(filePath))
            {
                FileStream stream = new FileStream(
                        filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                file = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();
            }

            return file;
        }
    }
}
