namespace ChannelEngineAssessmentDomain.Products
{
    public class ExtraImageUrl
    {
        public int No { get; private set; }
        public string Url { get; private set; }

        public ExtraImageUrl(int no, string url)
        {
            No = no;
            Url = url;
        }

        public void Update(string url)
        {
            Url = url;
        }
    }
}