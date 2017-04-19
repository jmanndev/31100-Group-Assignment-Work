# 31100-Group-Assignment-Work #
**Team Name:** Triple-J Gee
* Jonathan Mann (11393269)
* Jenny Nguyen (11236662)
* Wen Yen George Du (11747969)
* Jordan Labonne (12002491)

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

## Pages to Do ##
See below for list of pages that are pending.  Please mark the progress on them as you work on it.

|Screen|Status|Notes|
|---|---|---|
|Login|in progress||
|Registration|in progress||
|Main Page (page changes based on user role: site engineer, manager, accountant)|not impemented|assumes site engineer currently|
|Report generation page|||
|View list of all clients|implemented||
|View/manage single client (with associated interventions) (could double as EDIT page)|in progress||
|Create a client|implemented|functionality/verification needs to be completed|
|View list of all interventions user is 'owner' of|||
|View list of all interventions|implemented||
|View list of all interventions filtered by status|||
|View/manage single intervention (could double as EDIT page)|||
|Create an intervention|||
|List of managers|||
|List of site Engineers|||
