/**
 * A dopdown box with features for create, read, update, and delete.
 */
webexpress.webapp.selectionCtrl = class extends webexpress.webui.selectionCtrl {
    _optionUri = "";
    _spinner = $("<div class='spinner-border spinner-border-sm text-secondary' role='status'/>");

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - Id Sets the id of the control.
     *        - CSS The css class used to design the control.
     *        - Placeholder The placeholder text.
     *        - OptionUri The uri of the rest api interface that collects the options.
     */
    constructor(settings) {
        super(settings);

        this._optionUri = settings.optionuri;
        this._optionfilter = function (x, y) { return true; };

        this._container.on('show.bs.dropdown', function () {
            this.receiveData(this._filter.val());
        }.bind(this));
    }

     /**
      * Retrieve data from rest api.
      * @param filter Die Filtereinstellungen
      */
    receiveData(filter) {

        filter = filter !== undefined || filter != null ? filter : "";
        this._selection.append(this._spinner);

         $.ajax({ type: "GET", url: this._optionUri + "?search=" + filter + "&page=0", dataType: 'json', }).then(function (response) {
             var data = response.data;

             this.options = data;
             this.trigger('webexpress.webui.receive.complete');

             //this.update();

             this._selection.children("div").remove();
         }.bind(this));
    }
}