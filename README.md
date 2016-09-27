# Babysitter-Kata
Solution for the Babysitter Code Kata.

Problem Statement:
Babysitter Kata

Background
----------
This kata simulates a babysitter working and getting paid for one night.  The rules are pretty straight forward:

The babysitter 
- starts no earlier than 5:00PM
- leaves no later than 4:00AM
- gets paid $12/hour from start-time to bedtime
- gets paid $8/hour from bedtime to midnight
- gets paid $16/hour from midnight to end of job
- gets paid for full hours (no fractional hours)


Feature:
As a babysitter
In order to get paid for 1 night of work
I want to calculate my nightly charge

--  Credit: https://gist.github.com/jameskbride/5482722

Assumed conditions:
- When time extends into two blocks (e.g before bed time and after bed time), costs for both blocks are added up.

Running the Unit Tests
--------------
1. Open the solution in Visual Studio. The solution file was generated with Visual Studio 2015 Enterprise Edition.
2. Run the tests in the BabySitterUnitTests project. Shortcut key CTRL+R, A.
3. The test project has 15 tests created for TDD.
