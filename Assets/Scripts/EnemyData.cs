using System;

[Serializable]
public class Name
{
    public string title;
    public string first;
    public string last;
}

[Serializable]
public class Picture
{
    public string medium;
}

[Serializable]
public class Result
{
    public Name name;
    public Picture picture;
}

[Serializable]
public class Info
{
    public int seed;
    public int results;
    public int page;
    public string version;
}

[Serializable]
public class RootObject
{
    public Result[] results;
    public Info info;
}
