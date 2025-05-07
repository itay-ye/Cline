# Cloning the Project (Windows)

1.  Open your command prompt or PowerShell.
2.  Navigate to the directory where you want to clone the project.
3.  Run the following command:
    ```bash
    git clone [YOUR_PROJECT_REPOSITORY_URL_HERE]
    ```
4.  Once cloned, you can open the `Cline` folder in VS Code.

---

# Cline Workshop - Your AI Coding Buddy!

## Hey there, Future Cline Pro! 👋

Welcome to the Cline workshop! Get ready to supercharge your coding with your new AI assistant, Cline. We'll be working with a .NET Web API project to see how Cline can help you build, debug, and manage your code like a champ.

## What You'll Need:
*   .NET SDK (make sure it's installed!)
*   VS Code (our awesome code editor)
*   The Cline Extension for VS Code (that's me!)

## Project Sneak Peek:
We've got a cool little project called `InventoryApi`. Here's the basic layout:
*   `InventoryApi/`: This is where the main API magic happens.
    *   `Controllers/`: Handles incoming web requests.
    *   `Models/`: Defines the data structures (like what a 'Product' looks like).
    *   `Services/`: Contains the smarts (business logic).
    *   `Data/`: Talks to the (pretend) database.
*   `InventoryApi.Tests/`: Where we keep the tests to make sure our code is behaving.

## Let's Get This Workshop Started! 🚀

Here’s our game plan:

### Step 1: Gear Up & Meet Cline!

First things first, let's make sure your VS Code is decked out with the best tools for the job.

1.  **Install Recommended Extensions:**
    This project has a list of handy extensions that make .NET development smoother. VS Code might have already prompted you to install them. If not, open the Command Palette (Ctrl+Shift+P or Cmd+Shift+P on Mac), type "Extensions: Show Recommended Extensions", and hit Enter. You should see these:
    *   `ms-dotnettools.csharp`
    *   `ms-dotnettools.csdevkit`
    *   `visualstudioexptteam.vscodeintellicode-csharp`
    *   `cline.vscode-cline` (That's me!)
    *   `github.copilot`
    *   `github.copilot-chat`

    Go ahead and install them if they're not already there!

2.  **Set Up Cline:**
    Once the `cline.vscode-cline` extension is installed, you'll need to configure it:
    *   **API Key:** Cline requires an API key to function. You will need to provide your own API key in the extension settings.
    *   **Language Model API:** In the Cline extension settings, ensure you select "VS Code LM API" (or the appropriate language model provider as instructed).

3.  **Quick Intro to Cline (Your AI Pal):**
    So, who am I? I'm Cline, an AI coding assistant living right inside your VS Code. Think of me as a super-smart pair programmer. You can ask me to:
    *   Read and understand code.
    *   Write new code or modify existing stuff.
    *   Run commands in the terminal.
    *   Search for things in your project.
    *   Help you figure out errors.
    *   And lots more!

    **How is Cline different from GitHub Copilot?**
    While both Cline and GitHub Copilot are AI coding assistants, they have different focuses. GitHub Copilot excels at code completion and generating code snippets based on comments or existing code. Cline, on the other hand, is designed to be more of an interactive "buddy" that can perform a wider range of tasks within your IDE. Cline uses a suite of tools to understand your project, execute commands, read and modify files, and help you with debugging and refactoring in a more conversational and step-by-step manner. Think of Copilot as a fast typist for code, and Cline as a versatile assistant that can actively work *with* you on your project.

    You'll chat with me in a dedicated Cline panel. You give me tasks, and I use my "tools" (like reading files or running commands) to get things done. We'll see this in action very soon!

### Step 2: Let's Try to Run This Thing (and maybe break it a little 😉)

Every good developer knows the first step is to see if the project even runs!

1.  **Open a Terminal:** In VS Code, you can open a new terminal by going to "Terminal" > "New Terminal" in the top menu.
2.  **Navigate to the API Project:** In the terminal, type:
    ```bash
    cd InventoryApi
    ```
    This takes you into the main project folder.
3.  **Try to Run It:** Now, let's try to start the API. Type:
    ```bash
    dotnet run
    ```
    Uh oh! You'll probably see some scary red error messages. Don't worry, this is on purpose!

4.  **Ask Cline for Help:**
    Now, let's get Cline to figure this out. In the Cline chat, you can send a message like this:

    ```
    The project isn't running. Can you look at the terminal output and help me fix it?
    Here's the error:
    [Paste the error message from your terminal here]
    ```

    Cline will then analyze the error and the `.csproj` file and tell you which package is missing and how to add it!

### Step 3: Squash That Failing Test!

Our project has some automated tests to check if everything works as expected. Let's run them and fix any that are grumpy.

1.  **Navigate to the Test Project:** In your terminal (make sure you're in the `c:/Users/itayyeshaya/workshops/Cline` directory first, then `cd InventoryApi.Tests`).
2.  **Run the Tests:** Type:
    ```bash
    dotnet test
    ```
    You should see at least one test failing. Pay attention to its name!

3.  **Get Cline on the Case:**
    Let Cline help you figure out what's wrong with the failing test. You can tell Cline:

    ```
    One of my tests is failing. It's called [Name of the failing test].
    Can you look at the test file `InventoryApi.Tests/ProductServiceTests.cs` and the related code in `InventoryApi/Services/ProductService.cs` to help me find and fix the bug?
    ```

### Step 4: The Case of the Sneaky Stock Bug! 🕵️‍♀️

Imagine a customer support ticket comes in: "Help! Sometimes when we update product prices, the stock levels go totally bonkers! It's like the system gets confused and changes the stock to a weird number. We don't know why or where it's happening, but it's causing chaos with our inventory!"

This sounds like a tricky bug! It's not obvious, and it's hidden somewhere in the code.

 **Prompt Cline for Detective Work:**
    You need to guide Cline to find this. Since the customer report is a bit vague, you'll need to be clever. Try a prompt like this:

    Users are reporting that when they update a product's price, the stock quantity sometimes changes unexpectedly please fix it.

### Step 5: Let's Build Something New! (With Planning!)

Time to add a new feature! Let's say a Jira ticket comes in: "As a user, I want to be able to manage 'Supplier' information for our products. We need basic CRUD (Create, Read, Update, Delete) operations for Suppliers. Each supplier should have an ID, Name, Contact Email, and a list of Product IDs they supply."

This is a bigger task! We'll use Cline's **PLAN MODE** to map this out before coding.

1.  **Switch to PLAN MODE with Cline:**
    In the Cline chat, you'll usually be in "ACT MODE" where Cline tries to do things immediately. For bigger tasks, you can ask Cline to switch to "PLAN MODE".

2.  **Brainstorm with Cline:**
    Give Cline the Jira task. A good prompt would be:

    ```
    I need to add a new feature to manage 'Suppliers'.
    Requirements:
    - New data type: `Supplier` (ID, Name, ContactEmail, List of ProductIDs).
    - CRUD operations: Create, Read (all and by ID), Update, Delete for Suppliers.
    - This will involve creating a new Model, updating the DbContext, creating a new Service, and a new Controller.

    Can you outline a plan for how we can implement this? What files would you create/modify, and what would the new `Supplier` class and controller methods look like?
    ```

    Cline will then discuss the plan with you: what files to create, what the code might look like, etc. You can go back and forth until you're happy with the plan.

3.  **Switch to ACT MODE and Build:**
    Once you and Cline have a solid plan, ask Cline to switch back to "ACT MODE" and start implementing the changes, step-by-step!

### Step 6: Keeping Cline (and our README) in Line!

Cline is powerful, but sometimes we want to give it specific, project-wide rules. For example, "Hey Cline, whenever you add a new API endpoint, make sure you also update the `README.md` file with its documentation!"

This is where `.clinerules` files come in.

1.  **What are `.clinerules`?**
    A `.clinerules` file (you create it in the root of your project) lets you give Cline custom instructions or "rules" to follow for this specific project. It helps ensure consistency and makes Cline even more tailored to your workflow.

2.  **Creating a Rule to Update the README:**
    Let's create a rule. In the root of your `Cline` workshop folder, create a file named `.clinerules` (yes, starting with a dot).
    Inside this file, you can write instructions in plain English. For our README example, it might look something like this:

    ```
    # Custom Rules for Cline in the InventoryApi Project

    ## Rule: Document New Endpoints in README

    When a new API endpoint is added or significantly modified in any controller (e.g., in `ProductsController.cs` or any new controller):
    1.  You MUST update the `README.md` file.
    2.  The README update should include:
        *   The purpose of the new endpoint.
        *   The HTTP method (GET, POST, etc.) and the full request URL.
        *   A sample request body (if applicable, in JSON format).
        *   A sample response body (in JSON format).
    3.  Place this documentation under a relevant section in the README, possibly creating a new subsection if needed.
    ```

3.  **How Cline Uses It:**
    Now, when you ask Cline to do something that triggers this rule (like adding a new endpoint), Cline will remember to also update the README according to your instructions! It's like giving Cline a project-specific checklist.

## You Did It! 🎉

Congratulations on completing the Cline workshop! You've seen how Cline can help you:
*   Set up your environment.
*   Diagnose and fix runtime errors.
*   Debug failing tests.
*   Uncover sneaky logical bugs.
*   Plan and implement new features.
*   Customize its behavior with project-specific rules.

Keep exploring with Cline, and happy coding!
