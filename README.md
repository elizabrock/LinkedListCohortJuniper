# CSharpSinglyLinkedLists

Cohort Grape (7) Linked List Project.

This is the C# equivalent of https://github.com/elizabrock/linked_list_cohort_blueberry


Instructions
-----------

  1. Refresh your memory of unit testing by reading:
    * http://en.wikipedia.org/wiki/Test-driven_development
    * http://www.extremeprogramming.org/rules/unittests.html
  2. Fork this repository and clone your fork
  3. Open SinglyLinkedLists.sln
  4. [Use the TestExplorer to "Run All" Unit Tests.](http://msdn.microsoft.com/en-us/library/ms182470.aspx)
  5. Make the test suite pass by implementing the SinglyLinkedList and SinglyLinkedListNode classes
    * Choose one test at a time to work on
    * Once the tests pass, you should refactor and clean up your code
  6. Push your implementation up to github as you work on it.

Test Run Modes
--------------

Note that there are individual Unit Tests, as well as two [Ordered Tests](http://msdn.microsoft.com/en-us/library/ms182629(v=vs.90).aspx) (`BasicLinkedListImplementation` and `AdvancedLinkedListImplementation`). 

The ordered test files run the tests in a fixed order, which can guide your implementation, Koans-style.  Or, you can choose individual Unit Tests to focus on and implement methods in an order of your own choosing.

More Information
----------------

There are multiple projects in this Visual Studio Solution (`sln`).  This may be the first time you've worked with multiple projects at the same time.

The solution contain:
  * A Library Project, SinglyLinkedLists
  * A Unit Test Project, UnitTestSinglyLinkedLists
  * A WPF application, SinglyLinkedListVisualizer

Visualizing Your LinkedLists
----------------------------

If you press the "Start" button in VisualStudio, it will run the SinglyLinkedListVisualizer application, which will create and show a visualization of a SinglyLinkedList.  You can run various methods from within the SinglyLinkedListVisualizer, in order to visually see their effects on the SinglyLinkedList and its SinglyLinkedListNodes.
