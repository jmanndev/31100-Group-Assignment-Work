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
|Create an intervention|files exist||
|View/manage single intervention (could double as EDIT page)|||
|View list of all interventions|implemented||
|View list of all interventions user is 'owner' of|||
|View list of all interventions filtered by status|||
|List of managers|||
|List of site engineers|||
|Report generation page|||

## To run project ##
### update `IIS\config\applicationhost.config` ###
The project is now reading the `IIS\config\applicationhost.config` file instead of the `applicationhost.config` file found in our project as we all have different physical paths to our copy of the project. `.gitignore` has been updated to ignore redundant changes made to our project's `applicationhost.config` file and it won't be in Github's repo.

Steps to update your IIS's `applicationhost.config`
1. Open `applicationhost.config` for EDITING that's in `%userprofile%\documents\iisexpress\config\`, e.g. `C:\Users\knockycode\documents\iisexpress\config\`
2. Open `applicationhost.config` for VIEW that's in `\31100-Group-Assignment-Work\InterventionMonitor\.vs\` and look for code that looks like below
```xml
<site name="InterventionMonitor" id="2">
    <application path="/" applicationPool="Clr4IntegratedAppPool">
      <virtualDirectory path="/" physicalPath="C:\Users\knockycode\Documents\GitHub\31100-Group-Assignment-Work\InterventionMonitor\InterventionMonitor" />
    </application>
    <bindings>
        <binding protocol="http" bindingInformation="*:28737:localhost" />
    </bindings>
</site>
```
And paste it over in the file specified in step 1 within the `<sites>` tag. Like so:
```xml
<sites>
    <site name="WebSite1" id="1" serverAutoStart="true">
        <application path="/">
            <virtualDirectory path="/" physicalPath="%IIS_SITES_HOME%\WebSite1" />
        </application>
        <bindings>
            <binding protocol="http" bindingInformation=":8080:localhost" />
        </bindings>
    </site>
    <site name="PetesPersonalTraining" id="2">
        <application path="/" applicationPool="Clr4IntegratedAppPool">
            <virtualDirectory path="/" physicalPath="E:\PetesPersonalTraining\PetesPersonalTraining" />
        </application>
        <bindings>
            <binding protocol="http" bindingInformation="*:23275:localhost" />
        </bindings>
    </site>
    <site name="InterventionMonitor" id="3">
        <application path="/" applicationPool="Clr4IntegratedAppPool">
          <virtualDirectory path="/" physicalPath="C:\Users\knockycode\Documents\GitHub\31100-Group-Assignment-Work\InterventionMonitor\InterventionMonitor" />
        </application>
        <bindings>
            <binding protocol="http" bindingInformation="*:28737:localhost" />
        </bindings>
    </site>
  <!-- snipped code --> 
</sites>
```
Ensure the `id` is unique to the other sites!

### add `connectionstrings.config` file ###
Our project's `web.config` file now reads the DB connection string from a `connectionstrings.config` file. `.gitignore` has been updated to ignore any changes made to `connectionstrings.config` and it won't be in Github's repo.

1. Create a `connectionstrings.config` file in the same directory as the `web.config` file.
2. Add your connectionString there -- ensure it's within a `connectionStrings` tag.
Here's a working example of a `connectionstrings.config` file:
```xml
<connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\knockycode\Documents\GitHub\31100-Group-Assignment-Work\InterventionMonitor\InterventionMonitor\App_Data\aspnet-InterventionMonitor-20170403115219.mdf;Integrated Security=True;Connect Timeout=30" providerName="System.Data.SqlClient" />
</connectionStrings>
```

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