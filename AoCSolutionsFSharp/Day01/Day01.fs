namespace AoCSolutionsFSharp

open NUnit.Framework

module Day01 =
    
    let Solve (x:string) =
        let convertToInt = string >> int
        x.Split('\n') |> Array.sumBy convertToInt

    let SolvePart2 (x:string) =
        let convertToInt = string >> int
        x.Split('\n') |> Array.sumBy convertToInt
    
    [<Test>] 
    let ``Solve Part 1``() = 
      Assert.That(Solve Input.Puzzle, Is.EqualTo(406))

    [<Test>] 
    let ``Solve Part 2``() = 
      Assert.That(SolvePart2 Input.Puzzle, Is.EqualTo(312))