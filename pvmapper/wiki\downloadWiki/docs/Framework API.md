# Objects available to the plugins

Proposed pvMapper object
## pvMapper
**Properties**
* map = The OpenLayers.map object created in the viewport
* toolbar = The toolbar above the map. Only a few plugins will add buttons here.
**Methods**
* postScore = Adds a score to the database
* postSite
* getSite
* createWizard = A set of dialogs that can collect form data for a plugin (Wizard object needs to be created still)
**Events**
onReady