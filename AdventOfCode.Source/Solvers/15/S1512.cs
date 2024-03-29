using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class S1512 : BaseSolver
{
    public S1512(string input)
        : base(input)
    {
        var sum = 0;
        var jsonString = Input[0];
        dynamic json = JsonConvert.DeserializeObject(jsonString)
            ?? throw new Exception("No jsonString passed in.");

        foreach (JToken jsonObject in json)
        {
            sum += Process(jsonObject);
        }

        // remove the section commented below to get answer 1
        Answer1 = sum.ToString();
    }

    private int Process(JToken jsonObject)
    {
        switch (jsonObject.Type)
        {
            case JTokenType.Array:
                return ProcessArray(jsonObject);
            case JTokenType.Integer:
                return jsonObject.Value<int>();
            case JTokenType.Property:
                return ProcessProperty(jsonObject);
            case JTokenType.Object:
                return ProcessObject(jsonObject);
            default:
                return 0;
        }
    }

    private int ProcessObject(JToken jsonObject)
    {
        var objectSum = 0;
        foreach (var objectObject in jsonObject)
        {
            // checks for "red" - remove this to get answer 1
            if (objectObject.Type == JTokenType.Property)
            {
                var objProp = objectObject.Value<JProperty>()
                    ?? throw new Exception("cannot cast to JProperty");
                if (objProp.Value.Type == JTokenType.String &&
                    objProp.Value.Value<string>() == "red")
                {
                    return 0;
                }
            }

            objectSum += Process(objectObject);
        }

        return objectSum;
    }

    private int ProcessProperty(JToken jsonObject)
    {
        var property = jsonObject.Value<JProperty>()
                            ?? throw new Exception("unable to cast into JProperty");
        if (property.Value.Type == JTokenType.Integer)
        {
            return property.Value.Value<int>();
        }
        else
        {
            return Process(property.Value);
        }
    }

    private int ProcessArray(JToken jsonObject)
    {
        var arraySum = 0;
        foreach (var arrayObject in jsonObject)
        {
            arraySum += Process(arrayObject);
        }

        return arraySum;
    }
}