# 31100-Group-Assignment-Work #
**Team Name:** Triple-J Gee
* Jonathan Mann (11393269)
* Jenny Nguyen (11236662)
* Wen Yen George Du (11747969)
* Jordan Labonne (12002491)

## Pages to Do ##
See below for list of pages that are pending.  Please mark the progress on them as you work on it.

|Screen|Status|Notes|
|---|---|---|
|Login|in progress||
|Registration|in progress||
|Main Page (page changes based on user role: site engineer, manager, accountant)|files exist|assumes site engineer currently|
|Create a client|implemented|could implement some form of data validation other than not null, otherwise completed|
|View/manage single client (with associated interventions) (could double as EDIT page)|in progress|displays dummy data, needs to implement db connection|
|View list of all clients|implemented||
|Create an intervention|in progress|display logged in engineer's district; display only clients in same district; implement approval and propose; displays in-memory data, needs to implement db connection|
|View/manage single intervention|in progress|implement cancel, approval, complete and inspected; displays in-memory data, needs to implement db connection|
|View list of all interventions|implemented|displays in-memory data, needs to implement db connection|
|View list of all interventions user is 'owner' of|||
|View list of all interventions filtered by status|||
|List of managers|||
|List of site engineers|||
|Report generation page|||

## To run project ##
### update `IIS\config\applicationhost.config` ###
The project is now reading the `IIS\config\applicationhost.config` file instead of the `applicationhost.config` file that used to be in our repo because we all have different physical paths to our copy of the project.

Opening the project in Visual Studio 2015 would attempt to edit the `applicationhost.config` file with a `<site>` entry within the `<sites>` entry collection, but in case that it doesn't the following is an example template:
```xml
<site name="InterventionMonitor" id="3">
    <application path="/" applicationPool="Clr4IntegratedAppPool">
      <virtualDirectory path="/" physicalPath="C:\Users\knockycode\Documents\GitHub\31100-Group-Assignment-Work\InterventionMonitor\InterventionMonitor" />
    </application>
    <bindings>
        <binding protocol="http" bindingInformation="*:28737:localhost" />
    </bindings>
</site>
```

Ensure the `id` is unique to the other sites!

### add `connectionstrings.config` file ###
Our project's `web.config` file now reads the DB connection string from a `connectionstrings.config` file. `.gitignore` has been updated to ignore any changes made to `connectionstrings.config` and it won't be in Github's repo.

1. Create a `connectionstrings.config` file in the same directory as the `web.config` file.
2. Add your connectionString to the ENET DB and to the ECare2 DB there -- ensure it's within a `connectionStrings` tag.
Here's a working example of a `connectionstrings.config` file:
```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=REMAC-WINDOWS;Initial Catalog=ENET;Integrated Security=True" providerName="System.Data.SqlClient" />
  <add name="DataConnection" connectionString="Data Source=REMAC-WINDOWS;Initial Catalog=ECare2;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```
3. Make a copy of this `connectionStrings.config` file outside the repo. Just in case you need to delete the repo and download it again from Github and to avoid re-creating this file from scratch.

## Code Standards ##
### Project ###
- Backing fields (AKA class variables) that are used in calculated Properties should have an underscore prefix so we know which class variable has a Property that we should be using instead. Especially when displaying the Property to the user.
  E.g.
  ```c
  private String _score;
  public String Score
  {
    get { return "Score: " + _score; }
    private set { _score = value; }
  }

  private int serverPoint, receiverPoint; // no need for underscore prefix
  ```
  **Unless** the backing field isn't going to be referenced anywhere else in the code AND the Property that uses the backing field is a simple get and set, then just remove the backing field.
  E.g.
  ```c
  // acceptable
  public int StudentID { get; private set; }

  // also acceptable but we should really pick the above or this one and stick with it
  public int StudentID
  {
    get;
    private set;
  }

  // Not acceptable as the backing field is just unused and there's redundant code.
  private int _studentID;
  public int StudentID
  {
    get { return _studentID; }
    private set { _studentID = value; }
  }
  ```
- Boolean class variables should be named with an `is` (or `are` for plurals) prefix,  e.g. `public bool isApproved` or `public bool areValidEntries`
- Tab spaces. Use default VS2015 Community settings which seems to be Tab Size 4. Indent Size 4. Insert Spaces.
### Version Control ###
- For each commit message, have it start with an active verb. E.g. `Update code standards on README file.`
