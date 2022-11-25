using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class S12 : BaseSolver
{
    public S12(string input) : base(input)
    {
        var sum = 0;
        var jsonString = _input[0];
        dynamic json = JsonConvert.DeserializeObject(jsonString)
            ?? throw new Exception("No jsonString passed in.");

        foreach (JToken jsonObject in json)
        {
            sum += Process(jsonObject);
        }

        // 10766 is too low
        _answer1 = sum.ToString();
    }

    private int Process(JToken jsonObject)
    {
        if (jsonObject.Type == JTokenType.Array)
        {
            var arraySum = 0;
            foreach (var arrayObject in jsonObject)
            {
                arraySum += Process(arrayObject);
            }
            return arraySum;
        }
        else if (jsonObject.Type == JTokenType.Integer)
        {
            return jsonObject.Value<int>();
        }
        else if (jsonObject.Type == JTokenType.Property)
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
        else if (jsonObject.Type == JTokenType.Object)
        {
            var objectSum = 0;
            foreach (var objectObject in jsonObject)
            {
                objectSum += Process(objectObject);
            }
            return objectSum;
        }

        return 0;
    }
}