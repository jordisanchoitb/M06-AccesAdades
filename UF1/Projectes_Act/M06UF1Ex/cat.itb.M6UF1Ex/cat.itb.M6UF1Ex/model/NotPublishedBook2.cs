namespace cat.itb.M6UF1Ex;

public class NotPublishedBook2
{
    public int _id { get; set; }
    public string title { get; set; }
    public string isbn { get; set; }
    public int pageCount { get; set; }
    public PublishedDate publishedDate { get; set; }
    public string shortDescription { get; set; }
    public string longDescription { get; set; }
    public string status { get; set; }
    public List<string> authors { get; set; }
    public List<string> categories { get; set; }
    public int Assessment { get; set; }

    public override string ToString()
    {
        return
            "Book{" +
            "_id = '" + _id + '\'' +
            ",title = '" + title + '\'' +
            ",isbn = '" + isbn + '\'' +
            ",publishedDate = '" + publishedDate + '\'' +
            ",shortDescription = '" + shortDescription + '\'' +
            ",longDescription = '" + longDescription + '\'' +
            ",status = '" + status + '\'' +
            ",authors = '" + authors + '\'' +
            ",categories = '" + categories + '\'' +
            "}";
    }
}