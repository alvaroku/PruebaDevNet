namespace Business.DTOs
{
    public class ResourceRequest
    {
        public Stream Stream { get; set; }
        public string FolderPath { get; set; }
        public string FileName {  get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
    }
}
