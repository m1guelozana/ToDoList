Console.WriteLine("Hello!");

bool shallExit = false;
var todos = new List<string>();
while (!shallExit)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");

    var choice = Console.ReadLine().ToUpper();

    switch (choice)
    {
        case "S":
            // get all todos
            getAllTodo();
            break;
        case "A":
            // add a todo
            AddTodo();
            break;
        case "R":
            // remove a todo
            RemoveTodo();
            break;
        case "E":
            // exit program
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid input. Select a valid choice.");
            break;
    }
}

Console.ReadKey();

void AddTodo()
{
    bool isValidDescription = false;
    while (!isValidDescription)
    {
        Console.WriteLine("Enter the TODO description: ");
        var description = Console.ReadLine();

        if (description == "")
        {
            Console.WriteLine("description cannot be empty");
        }
        else if (todos.Contains(description))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            isValidDescription = true;
            todos.Add(description);
        }
    }
}

void getAllTodo()
{
    if (todos.Count == 0)
    {
        showNoTodosMessage();
    }
    else
    {
        Console.WriteLine("All TODOS found: ");
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i}. {todos[i]}");
        }
    }
}

void RemoveTodo()
{
    if(todos.Count == 0)
    {
        Console.WriteLine("No TODOs found.");
        return;
    }
    bool isValidIndex = false;
    while (!isValidIndex)
    {
        Console.WriteLine("Select the index of the TODO you wantto remove.");
        getAllTodo();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Selected index cannot be empty.");
            continue;
        }
        if (int.TryParse(userInput, out int index) && index >= 1 && index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            isValidIndex = true;
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
        else
        {
            Console.WriteLine("The index is not valid.");
        }

    }
}

void showNoTodosMessage()
{
    Console.WriteLine("No TODOs found.");
}