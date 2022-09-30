# Assignment 1

## C♯
Clone this repository and bring the code pieces you need into your BDSA Assignments GitHub repository.

### Generics

Compare the following two methods:

```csharp
int GreaterCount<T, U>(IEnumerable<T> items, T x)
    where T : IComparable<T>;

int GreaterCount<T, U>(IEnumerable<T> items, T x)
    where T : U
    where U : IComparable<U>;
```

Both methods returns the amount of elements in `items` which are *greater than* `x`.

Explain in your own words what the type constraints mean for both methods.

#### Optional

Implement and test the latter of the two methods including a type hierarchy which supports the given type constraints.

### Iterators

Implement and test the following methods:

```csharp
IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items);

IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate);
```

1. `Flatten` takes as argument a stream of a stream of `T`'s. It should return a stream of `T`'s.

1. `Filter` takes as arguments a stream of `T`'s and a function which returns `true` or `false` when applied to an instance of `T`. It returns a stream of only the `T`s where the predicate returns `true`.

#### Notes

You must `yield` elements and not use a temporary in-memory collection.

You can declare a `Predicate` likes this:

```csharp
Predicate<int> even = Even;

bool Even(int i) => i % 2 == 0;
```

### Regular Expressions

Implement and test the following methods:

```csharp
IEnumerable<string> SplitLine(IEnumerable<string> lines);

IEnumerable<(int width, int height)> Resolutions(IEnumerable<string> resolutions);

IEnumerable<string> InnerText(string html, string tag);

IEnumerable<(Uri url, string title)> Urls(string html);
```

1. `SplitLine` takes as argument a stream of lines (strings) and returns a stream of the words on those lines (also strings).
A 'word' is a non-empty contiguous sequence of the letters a–z or A–Z or the digits 0–9. Use a regular expression to split the lines into words.

1. `Resolutions` takes a string containing resolutions. A resolution could be `1920x1080`. It returns a stream of resolutions as tuples, e.g. `(1920, 1080)`. The solution must use *named capture groups*.

   Sample input (one line represents an element in the `IEnumerable`):

    ```txt
    1920x1080
    1024x768, 800x600, 640x480
    320x200, 320x240, 800x600
    1280x960
    ```

    Sample output:

    ```txt
    (1920, 1080)
    (1024, 768)
    (800, 600)
    (640, 480)
    (320, 200)
    (320, 240)
    (800, 600)
    (1280, 960)
    ```

1. `InnerText` takes as arguments a string containing HTML and a specific tag name. It returns the *inner text* of each of those tags. Use a regular expression with a *back reference* to match tags.

1. `Urls` takes as argument a string containing HTML and returns all urls with their titles if any, otherwise `innerText`.

#### Notes

You must `yield` elements and not use a temporary in-memory collection.

Given the following `html` and the tag `a`:

```html
<div>
    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href="https://en.wikipedia.org/wiki/Theoretical_computer_science" title="Theoretical computer science">theoretical computer science</a> and <a href="https://en.wikipedia.org/wiki/Formal_language" title="Formal language">formal language</a> theory, a sequence of <a href="https://en.wikipedia.org/wiki/Character_(computing)" title="Character (computing)">characters</a> that define a <i>search <a href="https://en.wikipedia.org/wiki/Pattern_matching" title="Pattern matching">pattern</a></i>. Usually this pattern is then used by <a href="https://en.wikipedia.org/wiki/String_searching_algorithm" title="String searching algorithm">string searching algorithms</a> for "find" or "find and replace" operations on <a href="https://en.wikipedia.org/wiki/String_(computer_science)" title="String (computer science)">strings</a>.</p>
</div>
```

The `InnerText` method should return:

- theoretical computer science
- formal language
- characters
- pattern
- string searching algorithms
- strings

You should support nested html tags such that given the following `html` and the tag `p`:

```html
<div>
    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
</div>
```

The `InnerText` method should return:

> The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.

---

## Software Engineering


Let's say that the following is a natural language specification of a _version control system_:

  > I want a version control system that records changes to a file or set of files over time so that I can recall specific versions later.
  > This system should work on any kind of files may they contain source code, configuration data, diagrams, binaries, etc.
  > 
  > I want to use such a system to be able to revert selected files back to a previous state, revert the entire project back to a previous state, to compare changes over time, to see who last modified something that might be causing a problem, who introduced an issue and when, etc.


### Exercise 1

Use the noun/verb technique from _"Objects First with Java: A Practical Introduction Using BlueJ"_ chapter 15, to analyze the given description.

1. Explain in which domain nouns and verbs that you identified are located.
2. The implementation in [libgit2sharp](https://github.com/libgit2/libgit2sharp) does neither contain a class `File` nor a class `State`.
Explain how that can be when [libgit2sharp](https://github.com/libgit2/libgit2sharp) is an implementation of Git which is certainly a version control system as described above.


### Exercise 2

In class we discussed so far the Coronapas App and Git as cases for software systems.

1. Categorize each of the two systems into Sommervilles types of applications.
Note, the systems may not fall cleanly into a single category.
2. Argue for why you choose certain categories for each system.


### Exercise 3

Sommerville describes that there are two kinds of software products.
Describe for the Coronapas App and Git what kind of software product they are and provide arguments for your believes.


### Exercise 4

Sommerville discusses _quality of professional software_, non-functional quality attributes, or product characteristics.
Compare the Coronapas App, Git, and the Insulin pump control system (see SE chap 1.3.1) with respect to the quality attributes _dependability_, _security_, _efficiency_, and _maintainability_.

Do they all share the same characteristics with regards to these quality attributes or are these of varying importance to the three systems?
Give examples for each of the three systems with regards to each if the quality attributes above.


### Exercise 5

Inspect the implementations [Gitlet](http://gitlet.maryrosecook.com/docs/gitlet.html) and [Git](https://github.com/git/git/) a bit more thoroughly than in class.

1. Explain why is there likely no architecture for Gitlet.
2. How could you infer the architecture of Git that was depicted in class without any more documentation, i.e., only the available source code?
3. Gitlet has a particular design that mimics the architecture of Git but that is implemented differently. Can you describe it in words?
4. Git and Gitlet are designed with respect to different quality attributes (product characteristics). Name some of the most prominent quality attributes that influence the design of each of the two systems.


### Exercise 6

Look at the following two cases of issues with health care software systems:
  * [_"Softwareproblemer skadede mere end 100 patienter på amerikansk hospital"_](https://www.version2.dk/artikel/softwareproblemer-skadede-mere-end-100-patienter-paa-amerikansk-hospital)
  * [_"Kodefejl i Sundhedsplatformen: Fem patienter har fået forkert dosis medicin"_](https://www.version2.dk/artikel/kodefejl-i-sundhedsplatformen-fem-patienter-har-faaet-forkert-dosis-medicin)

1. Based on the articles, describe the reasons that caused the respective issues.
2. Describe potential solutions to the problem.
3. Compare your solutions to the proposed solutions in the articles, which one would you as a software engineer recommend? Argue for your recommendations.
4. Discuss ethical dilemas in case you were developing either of these health care systems.

---

## Submitting the assignment

To submit the assignment you need to create a PDF document using LaTeX that contains the answers to the questions **and** a link to a public GitHub repository that contains a fork of the assignments repository with the completed code.

The PDF file must conform to the following naming convention: `group_<x>_<id1>_<id2>_<id3>_assignment_01.pdf`, where `<x>` is replaced by the number of your group from [README_GROUPS.md](./README_GROUPS.md) and `<id1>`, `<id2>`, and `<id3>` are your respective ITU identifiers. 

You submit via [LearnIT](https://learnit.itu.dk/mod/assign/view.php?id=164354).