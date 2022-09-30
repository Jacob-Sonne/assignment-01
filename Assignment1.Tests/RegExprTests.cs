namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void SplitLine_given_empty_list_returns_empty_list()
    {
        // Arrange
        var input = new List<String> { };
        var expected = new List<String> { };

        // Act
        var actual = RegExpr.SplitLine(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SplitLine_given_list_of_empty_string_returns_empty_list()
    {
        // Arrange
        var input = new List<String> { "" };
        var expected = new List<String> {};

        // Act
        var actual = RegExpr.SplitLine(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolutions_given_empty_string_returns_empty_list()
    {
        // Arrange
        var input = String.Empty;
        var expected = new List<(int, int)> { };

        // Act
        var actual = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolutions_given_string_of_resolution_returns_list_of_resolutions()
    {
        // Arrange
        var input = "800x600";
        var expected = new List<(int, int)> { (800, 600) };

        // Act
        var actual = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Resolutions_given_string_of_resolutions_and_filler_returns_list_of_resolutions()
    {
        // Arrange
        var input = "800x600 awdasdaw 1024x768, 1920x1080,";
        var expected = new List<(int, int)> { (800, 600), (1024, 768), (1920, 1080) };

        // Act
        var actual = RegExpr.Resolution(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerText_given_empty_string_with_tag_returns_empty_list()
    {
        // Arrange
        var expected = new List<String>{};

        // Act
        var actual = RegExpr.InnerText("", "");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InnerText_given_html_string_and_tag_returns_list_of_innertext()
    {
        // Arrange
        var input = "<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p></div>";
        var tag = "a";
        var expected = new List<String>{"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"};        
        
        // Act
        var actual = RegExpr.InnerText(input, tag);

        // Assert
        Assert.Equal(expected, actual);
    }

}