using System;
using System.Collections.Generic;

/// <summary>
/// Main program for the Heltevagten emergency dispatch system.
/// </summary>
class Program
{
    // The dispatch center manages the heroes and incidents.
    private static DispatchCenter _dispatchCenter;

    // We keep references to the heroes so the menu can display them.
    private static List<Hero> _heroes = new List<Hero>();

    // We keep references to incidents so the menu can display them.
    private static List<Incident> _incidents = new List<Incident>();

    // Keeps track of which hero was assigned to which incident.
    private static Dictionary<Incident, Hero> _assignedHeroes =
        new Dictionary<Incident, Hero>();

    /// <summary>
    /// Starts the Heltevagten application.
    /// </summary>
    static void Main()
    {
        Console.Title = "Heltevagten";

        // FirstAvailableStrategy is the default strategy.
        IDispatchStrategy strategy =
            new FirstAvailableStrategy();

        _dispatchCenter = new DispatchCenter(strategy);

        CreateHeroes();

        bool running = true;

        while (running)
        {
            ShowMenu();

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ShowHeroes();
                    break;

                case "2":
                    ReportIncident();
                    break;

                case "3":
                    DispatchHero();
                    break;

                case "4":
                    ResolveIncident();
                    break;

                case "5":
                    ShowIncidents();
                    break;

                case "6":
                    ChooseDispatchStrategy();
                    break;

                case "7":
                    Search();
                    break;

                case "8":
                    TestCallbacks();
                    break;

                case "9":
                    ShowSignatureMoves();
                    break;

                case "10":
                    ShowGameInformation();
                    break;

                case "0":
                    running = false;
                    Console.WriteLine(
                        "Thank you for using Heltevagten.");
                    break;

                default:
                    Console.WriteLine(
                        "Invalid choice. Please choose an option from the menu.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    /// <summary>
    /// Displays the main menu.
    /// </summary>
    static void ShowMenu()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("              HELTEVAGTEN");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine("1. Show heroes");
        Console.WriteLine("2. Report incident");
        Console.WriteLine("3. Dispatch hero");
        Console.WriteLine("4. Resolve incident");
        Console.WriteLine("5. Show incidents");
        Console.WriteLine("6. Choose dispatch strategy");
        Console.WriteLine("7. Find heroes and incidents");
        Console.WriteLine("8. Test callbacks");
        Console.WriteLine("9. Show hero signature moves");
        Console.WriteLine("10. Game information");
        Console.WriteLine("0. Quit");

        Console.WriteLine();
    }

    /// <summary>
    /// Creates and registers the heroes used by the application.
    /// </summary>
    static void CreateHeroes()
    {
        HealingHero healingHero =
            new HealingHero("Healing Hero", 80);

        StrongHero strongHero =
            new StrongHero("Strong Hero", 100);

        FlyingHero flyingHero =
            new FlyingHero("Flying Hero", 90);

        _heroes.Add(healingHero);
        _heroes.Add(strongHero);
        _heroes.Add(flyingHero);

        _dispatchCenter.RegisterHero(healingHero);
        _dispatchCenter.RegisterHero(strongHero);
        _dispatchCenter.RegisterHero(flyingHero);
    }

    /// <summary>
    /// Displays all registered heroes.
    /// </summary>
    static void ShowHeroes()
    {
        Console.WriteLine("HEROES");
        Console.WriteLine("------");

        foreach (Hero hero in _heroes)
        {
            Console.WriteLine(
                $"{hero.Name} | Energy: {hero.EnergyLevel} | " +
                $"Available: {hero.IsAvailable}");
        }
    }

    /// <summary>
    /// Creates a new incident and reports it to the dispatch center.
    /// </summary>
    static void ReportIncident()
    {
        Console.WriteLine("REPORT INCIDENT");
        Console.WriteLine("---------------");
        Console.WriteLine("1. Medical emergency");
        Console.WriteLine("2. Car accident");
        Console.WriteLine("3. Fire");
        Console.WriteLine("4. Person needs help");
        Console.WriteLine("5. Animal rescue");

        Console.Write("Choose an emergency: ");
        string choice = Console.ReadLine();

        Incident incident;

        switch (choice)
        {
            case "1":
                incident = new Incident(
                    "Medical emergency",
                    "Copenhagen",
                    Severity.High);
                break;

            case "2":
                incident = new Incident(
                    "Car accident",
                    "Ballerup",
                    Severity.High);
                break;

            case "3":
                incident = new Incident(
                    "Fire",
                    "Hvidovre",
                    Severity.High);
                break;

            case "4":
                incident = new Incident(
                    "Person needs help",
                    "Copenhagen",
                    Severity.Medium);
                break;

            case "5":
                incident = new Incident(
                    "Animal rescue",
                    "Ballerup",
                    Severity.Medium);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        _dispatchCenter.ReportIncident(incident);
        _incidents.Add(incident);

        Console.WriteLine("Incident reported successfully.");
    }

    /// <summary>
    /// Assigns an available hero to an unresolved incident.
    /// </summary>
    static void DispatchHero()
    {
        Console.WriteLine("DISPATCH HERO");
        Console.WriteLine("-------------");

        Incident incident = FindUnresolvedIncident();

        if (incident == null)
        {
            Console.WriteLine(
                "No unresolved incidents were found.");
            return;
        }

        try
        {
            Hero hero =
                _dispatchCenter.AssignHero(incident);

            _assignedHeroes[incident] = hero;

            Console.WriteLine();
            Console.WriteLine(
                $"{hero.Name} was assigned to the incident.");
            Console.WriteLine(
                $"Location: {incident.Location}");
            Console.WriteLine(
                $"Description: {incident.Description}");
        }
        catch (NoSuitableHeroFoundException ex)
        {
            Console.WriteLine(
                $"No suitable hero: {ex.Message}");
        }
        catch (HeroUnavailableException ex)
        {
            Console.WriteLine(
                $"Hero unavailable: {ex.Message}");
        }
    }

    /// <summary>
    /// Finds the first unresolved incident.
    /// </summary>
    static Incident FindUnresolvedIncident()
    {
        return _dispatchCenter.FindFirst(
            _incidents,
            incident => !incident.IsResolved);
    }

    /// <summary>
    /// Resolves an incident and demonstrates a named callback.
    /// </summary>
    static void ResolveIncident()
    {
        Console.WriteLine("RESOLVE INCIDENT");
        Console.WriteLine("----------------");

        Incident incident = FindUnresolvedIncident();

        if (incident == null)
        {
            Console.WriteLine(
                "No unresolved incidents were found.");
            return;
        }

        _dispatchCenter.ResolveIncident(
            incident,
            OnIncidentResolved);
    }

    /// <summary>
    /// Callback method called when an incident is resolved.
    /// </summary>
    static void OnIncidentResolved(Incident incident)
    {
        Console.WriteLine(
            $"Incident resolved: {incident.Description} at " +
            $"{incident.Location}.");

        // Make the assigned hero available again.
        if (_assignedHeroes.ContainsKey(incident))
        {
            Hero hero = _assignedHeroes[incident];

            hero.SetAvailability(true);

            Console.WriteLine(
                $"{hero.Name} is available again.");

            _assignedHeroes.Remove(incident);
        }
    }

    /// <summary>
    /// Displays all incidents registered in the system.
    /// </summary>
    static void ShowIncidents()
    {
        Console.WriteLine("INCIDENTS");
        Console.WriteLine("---------");

        if (_incidents.Count == 0)
        {
            Console.WriteLine(
                "No incidents have been reported.");
            return;
        }

        foreach (Incident incident in _incidents)
        {
            Console.WriteLine(
                $"Description: {incident.Description}");
            Console.WriteLine(
                $"Location: {incident.Location}");
            Console.WriteLine(
                $"Severity: {incident.Severity}");
            Console.WriteLine(
                $"Resolved: {incident.IsResolved}");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Allows the user to choose between the three dispatch strategies.
    /// </summary>
    static void ChooseDispatchStrategy()
    {
        Console.WriteLine("CHOOSE DISPATCH STRATEGY");
        Console.WriteLine("-----------------------");
        Console.WriteLine("1. First available hero");
        Console.WriteLine("2. Strongest hero");
        Console.WriteLine("3. High severity");

        Console.WriteLine();
        Console.Write("Choose strategy: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _dispatchCenter =
                    new DispatchCenter(
                        new FirstAvailableStrategy());

                RegisterExistingHeroes();

                Console.WriteLine(
                    "First available hero strategy selected.");
                break;

            case "2":
                _dispatchCenter =
                    new DispatchCenter(
                        new StrongestHeroStrategy());

                RegisterExistingHeroes();

                Console.WriteLine(
                    "Strongest hero strategy selected.");
                break;

            case "3":
                _dispatchCenter =
                    new DispatchCenter(
                        new HighSeverityStrategy());

                RegisterExistingHeroes();

                Console.WriteLine(
                    "High severity strategy selected.");
                break;

            default:
                Console.WriteLine(
                    "Invalid strategy choice.");
                break;
        }
    }

    /// <summary>
    /// Registers the existing heroes in the new dispatch center.
    /// </summary>
    static void RegisterExistingHeroes()
    {
        foreach (Hero hero in _heroes)
        {
            _dispatchCenter.RegisterHero(hero);
        }
    }

    /// <summary>
    /// Searches heroes and incidents using the generic FindFirst method.
    /// </summary>
    static void Search()
    {
        Console.WriteLine("FIND HEROES AND INCIDENTS");
        Console.WriteLine("-------------------------");

        Console.WriteLine("1. Find hero by name");
        Console.WriteLine("2. Find high severity incident");

        Console.Write("Choose search: ");
        string choice = Console.ReadLine();

        Console.WriteLine();

        switch (choice)
        {
            case "1":
                SearchHero();
                break;

            case "2":
                SearchHighSeverityIncident();
                break;

            default:
                Console.WriteLine(
                    "Invalid search choice.");
                break;
        }
    }

    /// <summary>
    /// Searches the hero collection using the generic FindFirst method.
    /// </summary>
    static void SearchHero()
    {
        Console.Write("Enter hero name: ");
        string name = Console.ReadLine();

        Hero foundHero = _dispatchCenter.FindFirst(
            _heroes,
            hero => hero.Name.Equals(
                name,
                StringComparison.OrdinalIgnoreCase));

        if (foundHero != null)
        {
            Console.WriteLine(
                $"Generic search found: {foundHero.Name}");
        }
        else
        {
            Console.WriteLine(
                "Hero was not found.");
        }
    }

    /// <summary>
    /// Searches the incident collection using the same generic method.
    /// </summary>
    static void SearchHighSeverityIncident()
    {
        Incident foundIncident =
            _dispatchCenter.FindFirst(
                _incidents,
                incident =>
                    incident.Severity == Severity.High);

        if (foundIncident != null)
        {
            Console.WriteLine(
                $"Generic search found incident: " +
                $"{foundIncident.Description}");
        }
        else
        {
            Console.WriteLine(
                "No high severity incident was found.");
        }
    }

    /// <summary>
    /// Demonstrates both a named callback and a lambda callback.
    /// </summary>
    static void TestCallbacks()
    {
        Console.WriteLine("CALLBACK TEST");
        Console.WriteLine("-------------");

        // Named callback.
        Incident namedIncident =
            new Incident(
                "Cat stuck in a tree",
                "Copenhagen",
                Severity.Low);

        Console.WriteLine("Named callback:");

        _dispatchCenter.ResolveIncident(
            namedIncident,
            OnIncidentResolved);

        Console.WriteLine();

        // Lambda callback.
        Incident lambdaIncident =
            new Incident(
                "Runaway drone show",
                "Ballerup",
                Severity.Medium);

        Console.WriteLine("Lambda callback:");

        _dispatchCenter.ResolveIncident(
            lambdaIncident,
            incident =>
            {
                Console.WriteLine(
                    $"Lambda callback: {incident.Description} " +
                    $"at {incident.Location} was resolved.");
            });
    }

    /// <summary>
    /// Displays the signature move of every hero.
    /// </summary>
    static void ShowSignatureMoves()
    {
        Console.WriteLine("HERO SIGNATURE MOVES");
        Console.WriteLine("--------------------");

        foreach (Hero hero in _heroes)
        {
            Console.WriteLine(
                $"Signature move: {hero.UseSignatureMove()}");
        }
    }

    /// <summary>
    /// Displays information about the Heltevagten system.
    /// </summary>
    static void ShowGameInformation()
    {
        Console.WriteLine("GAME INFORMATION");
        Console.WriteLine("----------------");
        Console.WriteLine();

        Console.WriteLine(
            "Heltevagten is the city's superhero emergency");
        Console.WriteLine(
            "dispatch center.");
        Console.WriteLine();

        Console.WriteLine(
            "Citizens can report incidents, and the");
        Console.WriteLine(
            "dispatch center sends an available hero.");
        Console.WriteLine();

        Console.WriteLine("Heroes:");
        Console.WriteLine("- Healing Hero");
        Console.WriteLine("- Strong Hero");
        Console.WriteLine("- Flying Hero");
        Console.WriteLine();

        Console.WriteLine("The system can:");
        Console.WriteLine("- Register heroes");
        Console.WriteLine("- Report incidents");
        Console.WriteLine("- Dispatch heroes");
        Console.WriteLine("- Resolve incidents");
        Console.WriteLine("- Search heroes and incidents");
        Console.WriteLine("- Use different dispatch strategies");
    }
}
