[System.Serializable]

public class Speech
{
    public string index;
    public string text;
    public string next;
    public int wait;
    public bool exit = false;
    public ReplyOption[] replyOptions;
}