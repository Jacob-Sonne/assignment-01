namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_given_list_of_lists()
    {
        // Arrange
        var list = new List<List<int>>
        {
            new List<int> { 1, 2, 3},
            new List<int> { 4, 5, 6},
            new List<int> { 7, 8, 9}
        };
        var expected = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};

        // Act
        var actual = Iterators.Flatten(list);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Filter_given_list_of_ints_return_list_of_evens()
    {
        // Arrange
        var list = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9};
        Predicate<int> even = x => x % 2 == 0;
        var expected = new List<int>{2, 4, 6, 8};

        // Act
        var actual = Iterators.Filter(list, even);

        // Assert
        Assert.Equal(expected, actual);


    }
}