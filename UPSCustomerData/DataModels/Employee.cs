// Data Models

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Obj
{
    public Obj(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; }

    public string Value { get; set; }
}


public class Pagination
{
    public int total { get; set; }
    public int pages { get; set; }
    public int page { get; set; }
    public int limit { get; set; }
}

public class Meta
{
    public Pagination pagination { get; set; }
}

public class Datum
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public Gender gender { get; set; }
    public string status { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

}
public enum Gender
{
    Male,
    Female
};

public enum Status
{
    Active,
    InActve
};

public class Rootobject
{
    public int code { get; set; }
    public Meta meta { get; set; }

    //public Datum[] data { get; set; }

    public List<Datum> data { get; set; }
}


public class Jsonobjects
{
    public int id { get; set; }
    public Meta meta { get; set; }

    public Datum[] data { get; set; }

    //public List<UPSCustomerDetails> data { get; set; }
}


public class UPSCustomerDetails
{

    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("email")]
    public string email { get; set; }

    [JsonProperty("gender")]
    public Gender gender { get; set; }

    [JsonProperty("status")]
    public Status status { get; set; }

    [JsonProperty("created_at")]
    public string created_at { get; set; }

    [JsonProperty("updated_at")]
    public string updated_at { get; set; }

    //public List<UPSCustomerDetails> userdetails { get; set; }

    //public static IList<UPSCustomerDetails> products = new List<UPSCustomerDetails>();
}