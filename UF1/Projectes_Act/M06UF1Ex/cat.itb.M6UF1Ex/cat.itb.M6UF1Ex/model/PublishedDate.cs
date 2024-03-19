namespace cat.itb.M6UF1Ex;

public class PublishedDate
{
    public string date { get; set; }

    public override string ToString()
    {
        return
            "PublishedDate{" +
            "$date = '" + date + '\'' +
            "}";
    }
}