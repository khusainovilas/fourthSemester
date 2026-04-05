module BracketSequenceTests

open NUnit.Framework
open FsUnit
open BracketSequence

[<TestCase("", true)>]
[<TestCase("()", true)>]
[<TestCase("[]", true)>]
[<TestCase("{}", true)>]
[<TestCase("({[]})", true)>]
[<TestCase("(]", false)>]
[<TestCase("([)]", false)>]
[<TestCase("(", false)>]
[<TestCase(")", false)>]
[<TestCase("{[()]}", true)>]
[<TestCase("(tro[]lolo){}", true)>]
[<TestCase("a(b)c", true)>]
[<TestCase("abc", true)>]
[<TestCase("abc(]", false)>]
[<TestCase("(abc)", true)>]
let hasCorrectBrackets_bracketSequences_returnsCorrect (s: string) expected =
    hasCorrectBrackets s |> should equal expected