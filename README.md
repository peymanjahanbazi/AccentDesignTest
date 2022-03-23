# AccentDesignTest

## The Project is in "src" folder

# Technical Questions

## How long did you spend on the coding test? What would you add to your solution if you had more time?

two hours, I wrote more tests and I work on the UI

## What is the most useful feature that was recently added to .NET? Please include a snippet of code that shows how you've used it.

- using statement (used in the project)

```cs
namespace AccentDesignTest.Models.RemoteApi;

public class Class001
{
}
```

- switch (used in the Repository)

```cs
p.totalFeeChargedCalculated = p.erectedBoardType.title switch
{
    "sold" => p.totalFeeCharged * 1.075f,
    "sale agreed" => p.totalFeeCharged * 1.04f,
    _ => p.totalFeeCharged,
};
```

## How would you track down a performance issue in production? Have you ever had to do this?

- based on the problem I use different techniques.

  - Writing test codes
  - using online logging (Cloud watch)
  - using tools (Apache Jmeter)

- I had multiple cases that I workd on the improving the performance and finally I used caching, new data structures and, ...
