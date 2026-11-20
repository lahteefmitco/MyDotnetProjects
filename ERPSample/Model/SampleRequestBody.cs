namespace ERPSample.Model
{
    //Record was added in C# 9 and later, so Class was used instead. 
    //See more info: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
    public record SampleRequestBody
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public string Address { get; set; } =string.Empty;
    }
}
