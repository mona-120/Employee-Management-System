# Employee Management System

C# console App That demonstrate collections in C# (List, Dictionary, Queue, Stack, HashSet)

## Features:
* Add an Employee to Onboarding Queue by enter employee information in addition to a skill if there.
* Process employees from the Onboarding Queue in FIFO order to Activate them.
* Add new department by entering department name with auto-generated unique IDs.
* Add new Skill to employee after adding in Onboarding queue if needed.
* Search for an employee using name or id.
* View all active employees of specific department by entering department id.
* Calculate average salary in each department using loop that count employees in each department and sum their salary.
* Get count of employees in each department.
* Track all major actions in the system and store them, displayed from the latest action to the oldest because of using stack (LIFO).
* Display all unique skills that stored using HashSet that prevent duplicates.

---

## Code Review:
* Use Dictionary to store department information allow us to access any department using key in O(1) rather than search in all list O(n).
* Queue allow us to access employee in onboarding list in order as it work with FIFO.
* In our system we store Actions History that allow us to only display actions not make undo process that need to apply the opposite process.
* Using HashSet prevent duplicates as when we store an element in HashSet, it gives element a Hash code and when adding new element it check equality if Hash Code already exist that prevent duplication in O(1), Unlike List that need to make loop and condition to make sure that the element doesn't exist in the list.

