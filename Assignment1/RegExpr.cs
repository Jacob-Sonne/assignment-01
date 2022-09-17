namespace Assignment1;
using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        var pattern = @"\w+";
        foreach(var line in lines){
            var match = Regex.Match(line, pattern);
            while(match.Success){
                yield return match.Value;
                match = match.NextMatch();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions){
        var pattern = @"(?<width>\d+)x(?<height>\d+)";
        var match = Regex.Match(resolutions, pattern);
        while(match.Success){
            var width = Int16.Parse(match.Groups["width"].Value);
            var height = Int16.Parse(match.Groups["height"].Value);
            yield return (width, height);
            match = match.NextMatch();
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag){
        var pattern = $@"(<{tag}.*?)(.*?)>(?<InnerText>.*?)</{tag}>";
        var match = Regex.Match(html, pattern);
        while(match.Success){
            yield return match.Groups["InnerText"].Value;
            match = match.NextMatch();
        }
    }
}