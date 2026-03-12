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
let isCorrect_bracketSequences_returnsCorrect (s: string) expected =
    isCorrect s |> should equal expected