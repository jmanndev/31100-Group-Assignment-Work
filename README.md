# 31100-Group-Assignment-Work #
**Team Name:** Triple-J Gee
* Jonathan Mann (11393269)
* Jenny Nguyen (11236662)
* Wen Yen George Du (11747969)
* Jordan Labonne (12002491)

## Code Standards ##
### Project ###
- Backing fields (AKA class fields) that are used in Properties should have an underscore prefix.
  E.g.
  ```c
  private String _score;
  public String Score
  {
    get { return _score; }
    private set { _score = value; }
  }

  private int serverPoint, receiverPoint; // no need for underscore prefix
  ```

### Version Control ###
- For each commit message, have it start with an active verb. E.g. `Update code standards on README file.`
