Feature: NuGet Search
 As an end user,
 I would like to visit the NuGet search page
 And then I would like to search an item so that
 I can view the search results

@mytag
Scenario: NuGet Search Results
 Given I am on the NuGet home page
 When I search for text selenium
 Then I should see the search results