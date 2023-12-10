/**
 * A table with functions for create, read, update, and delete.
 */
webexpress.webapp.tableCtrl = class extends webexpress.webui.tableCtrl {
    _restUri = "";
    _searchCtrl = null;
    _paginationCtrl = null;
    _filter = null;
    _page = null;

    /**
     * Constructor
     * @param settings Options for styling the control:
     *        - id Sets the id of the control.
     *        - css The css class used to design the control.
     *        - placeholder The placeholder text.
     *        - resturi The uri of the rest api interface that collects the data.
     */
    constructor(settings) {
        super(settings);

        this._restUri = settings.resturi;

        $.ajax({ type: "GET", url: this._restUri + "?columns=true", dataType: 'json', }).then(function (response) {
            var columns = response.Columns;
            this.columns = columns;
        }.bind(this));

        this._searchCtrl = new webexpress.webui.searchCtrl({ Id: settings.id + "-search" });
        this._searchCtrl.on('webexpress.webui.change.filter', function (key) { this._filter = key; this.receiveData(); }.bind(this));
        this._paginationCtrl = new webexpress.webui.paginationCtrl({ Id: settings.Id + "-pagination" });
        this._paginationCtrl.on('webexpress.webui.change.page', function (page) { this._page = page; this.receiveData(); }.bind(this));
    }

    /**
     * Retrieve data from rest api.
     */
    receiveData() {
        if (this._filter === undefined || this._filter == null) { this._filter = ""; }
        if (this._page === undefined || this._page == null) { this._page = 0; }
        $.ajax({ type: "GET", url: this._restUri + "?wql=" + this._filter + "&page=" + this._page, dataType: 'json', }).then(function (response) {
            var data = response.data;
            this.clear();
            this.addRange(data);
            this.trigger('webexpress.webui.receive.complete');
            var pagination = response.pagination;
            this._paginationCtrl.page(pagination.pagenumber, pagination.totalpage);
        }.bind(this));
    }

    /**
    * Returns the control.
    */
    get getCtrl() {
        let div = $("<div/>")
        div.append(this._searchCtrl.getCtrl);
        div.append(this._table);
        div.append(this._paginationCtrl.getCtrl);
        return div;
    }
}