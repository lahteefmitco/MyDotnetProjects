namespace ERPSample.Model
{
    //Record was added in C# 9 and later, so Class was used instead. 
    //See more info: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
    public class SampleResponse
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }

    }
}
