namespace DSDD.DebatniMayhem.Web.Pages.Shared;

public class ActiveTopicModel
{
    public string Topic { get; }

    public string? InfoSlide { get; }

    public bool ShowTopic { get; }

    public ActiveTopicModel(string topic, string? infoSlide, bool showTopic)
    {
        Topic = topic;
        InfoSlide = infoSlide;
        ShowTopic = showTopic;
    }
}

