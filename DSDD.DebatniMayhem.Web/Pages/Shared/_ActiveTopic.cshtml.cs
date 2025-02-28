namespace DSDD.DebatniMayhem.Web.Pages.Shared;

public class ActiveTopicModel
{
    public string Topic { get; }

    public string? InfoSlide { get; }

    public bool ShowTopic { get; }

    public bool ShowInfoSlide { get; }

    public ActiveTopicModel(string topic, string? infoSlide, bool showTopic, bool showInfoSlide)
    {
        Topic = topic;
        InfoSlide = infoSlide;
        ShowTopic = showTopic;
        ShowInfoSlide = showInfoSlide;
    }
}

