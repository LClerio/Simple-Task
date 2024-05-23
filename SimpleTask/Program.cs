


using SimpleTask.Service;
using SimpleTask.Service.Enums;

List<TaskMaster> tasks = new List<TaskMaster>();
string userInput;

do
{
    Console.WriteLine("\nTo-Do List App");
    Console.WriteLine("1. Adicionar Tarefa");
    Console.WriteLine("2. Visualizar Tarefas");
    Console.WriteLine("3. Marcar Tarefa como Concluída");
    Console.WriteLine("4. Remover Tarefa");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            AddTask(tasks);
            break;
        case "2":
            ViewTasks(tasks);
            break;
        case "3":
            MarkTaskAsCompleted(tasks);
            break;
        case "4":
            RemoveTask(tasks);
            break;
        case "5":
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;

    }
} while (userInput != "5");

void AddTask(List<TaskMaster> tasks)
{
    Console.WriteLine("Digite a descrição da tarefa: ");
    string description = Console.ReadLine();
    Console.Write("Digite o código da tarefa: ");
    int.TryParse(Console.ReadLine(), out int codTask);

    tasks.Add(new TaskMaster(codTask, description, TasksStatus.Pending));
    Console.WriteLine("Tafera adicionada com sucesso");
}
void ViewTasks(List<TaskMaster> tasks)
{
    Console.WriteLine("\nLista de Tarefas:");
    if (tasks.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa encontrada.");

    } else
    {
        Console.WriteLine("Code. Tarefa - Status");
        Console.WriteLine();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].IsCompleted == TasksStatus.Pending)
            {
                Console.WriteLine($"{tasks[i].ID}. {tasks[i].Description} - {TasksStatus.Pending}  <<<");
            } else
            {
                Console.WriteLine($"{tasks[i].ID}. {tasks[i].Description} - {TasksStatus.Completed} <<< ✔");

            }
        }
    }
}
void MarkTaskAsCompleted(List<TaskMaster> tasks)
{
    ViewTasks(tasks);
    Console.Write("Digite o código da tarefa a ser marcada como concluída: ");
    if (int.TryParse(Console.ReadLine(), out int taskNunber))
    {
       TaskMaster task = tasks.Find(t => t.ID == taskNunber);
        if(task != null)
        {
            task.IsCompleted = TasksStatus.Completed;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
    } else
    {
        Console.WriteLine("código de tarefa inválido.");
    }

}
void RemoveTask(List<TaskMaster> tasks)
{
    ViewTasks(tasks);
    Console.Write("Digite o código da tarefa a ser removida: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber))
    {
        TaskMaster task = tasks.Find(t => t.ID == taskNumber);
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Tarefa removida com sucesso!");
        }
    } else
    {
        Console.WriteLine("código de tarefa inválido.");
    }
}

