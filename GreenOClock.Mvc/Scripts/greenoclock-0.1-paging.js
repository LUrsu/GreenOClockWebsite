$(document).ready(function () {
    $(".paged-list").each(function () {
        var pl = new PagedList($(this));
        if (pl.container.itemCount > 0)
            pl.setPage(1);
    });
});

function PagedList(domElement) {
    this.dom = $(domElement);
    var t = this;

    this.resultsPerPage = 10;
    if ($(this.dom).find('input[name="?resultsPerPage"]').size() != 0)
        this.resultsPerPage = parseInt($(this.dom).find('input[name="?resultsPerPage"]').first().val());
    this.currentPageNr = 0;

    this.container = new Container($(this.dom).find(".paged-container").first(), this.resultsPerPage);
    this.controls = $(this.dom).find(".paged-controls").map(function () {
        return new Control(this, t.container.pageCount, t);
    });

    this.setPageData = function (pageNr) {
        $(this.dom).find(".paged-data").each(function () {
            $(this).find(".paged-data-currentpage").first().text(pageNr);
            $(this).find(".paged-data-pagecount").first().text(t.container.pageCount);
        });
    };

    this.setPage = function (pageNr) {
        if (pageNr == this.currentPageNr || pageNr < 1 || pageNr > this.container.pageCount)
            return;
        this.container.displayPage(pageNr);
        $(this.controls).each(function () {
            this.displayPage(pageNr);
        });
        this.setPageData(pageNr);
        this.currentPageNr = pageNr;
    };
}

function Container(domElement, resultsPerPage) {
    this.dom = domElement;

    this.items = $(this.dom).children(".paged-container-item");
    this.itemCount = $(this.items).size();
    this.resultsPerPage = resultsPerPage;
    this.pageCount = Math.ceil(this.itemCount / resultsPerPage);

    this.showItems = function(start, end) {
        $(this.items).slice(start, end).show(0);
    };

    this.hideItems = function (start, end) {
        $(this.items).slice(start, end).hide(0);
    };

    this.getPageStart = function(pageNr) {
        return (pageNr - 1) * this.resultsPerPage;
    };

    this.getPageEnd = function(pageNr) {
        var end = pageNr * this.resultsPerPage;
        if (end > this.itemCount)
            end = this.itemCount;
        return end;
    };

    this.displayPage = function (pageNr) {
        this.hideItems(0, this.itemCount);
        this.showItems(this.getPageStart(pageNr), this.getPageEnd(pageNr));
    };
}

function Control(domElement, pageCount, obj) {
    this.dom = domElement;
    var t = this;

    this.maxPageJump = 2;
    if ($(this.dom).find('input[name="?maxPageJump"]').size() != 0)
        this.maxPageJump = parseInt($(this.dom).find('input[name="?maxPageJump"]').first().val());
    this.pageCount = pageCount;

    this.controlledObject = obj;

    this.init = function () {
        if (pageCount == 1) {
            $(this.dom).hide(0);
            return;
        }
        $(this.dom).find(".paged-control-first")
        .text("1")
        .click(function () {
            t.controlledObject.setPage(1);
        });
        $(this.dom).find(".paged-control-last")
        .text(this.pageCount)
        .click(function () {
            t.controlledObject.setPage(t.pageCount);
        });
    };
    this.init();

    this.removePrevActions = function () {
        $(this.dom).find(".paged-control-prev").unbind("click");
        $(this.dom).find(".paged-control-prevLinks .paged-control-prevLink").unbind("click");
    };

    this.setPrevActions = function (pageNr) {
        $(this.dom).find(".paged-control-prev").click(function () {
            t.controlledObject.setPage(pageNr - 1);
        });
        $(this.dom).find(".paged-control-prevLinks .paged-control-prevLink").each(function () {
            $(this).click(function () {
                t.controlledObject.setPage(parseInt($(this).text()));
            });
        });
    };

    this.setPrevLinks = function (pageNr) {
        this.removePrevActions();

        if (pageNr <= this.maxPageJump + 2)
            $(this.dom).find(".paged-controls-prevEtc").hide(0);
        else
            $(this.dom).find(".paged-controls-prevEtc").show(0);

        var prevLinks = $(this.dom).find(".paged-control-prevLinks");
        $(prevLinks).html("");
        for (var i = (pageNr - this.maxPageJump); i < pageNr; i++) {
            if (i <= 1)
                continue;
            $(prevLinks).append($('<a class="paged-control-prevLink">' + i + '</a>'));
        }

        this.setPrevActions(pageNr);
    };

    this.removeNextActions = function () {
        $(this.dom).find(".paged-control-next").unbind("click");
        $(this.dom).find(".paged-control-nextLinks .paged-control-nextLink").unbind("click");
    };

    this.setNextActions = function(pageNr) {
        $(this.dom).find(".paged-control-next").click(function () {
            t.controlledObject.setPage(pageNr + 1);
        });
        $(this.dom).find(".paged-control-nextLinks .paged-control-nextLink").each(function () {
            $(this).click(function () {
                t.controlledObject.setPage(parseInt($(this).text()));
            });
        });
    };

    this.setNextLinks = function(pageNr) {
        this.removeNextActions();

        var nextLinks = $(this.dom).find(".paged-control-nextLinks");
        $(nextLinks).html("");
        for (var i = pageNr + 1; i <= (pageNr + this.maxPageJump); i++) {
            if (i >= this.pageCount)
                break;
            $(nextLinks).append($('<a class="paged-control-nextLink">' + i + '</a>'));
        }

        if (pageNr >= this.pageCount - this.maxPageJump - 1)
            $(this.dom).find(".paged-controls-nextEtc").hide(0);
        else
            $(this.dom).find(".paged-controls-nextEtc").show(0);

        this.setNextActions(pageNr);
    };

    this.displayPage = function (pageNr) {
        if (pageNr == 1)
            $(this.dom).find(".paged-control-first").hide(0);
        else
            $(this.dom).find(".paged-control-first").show(0);

        this.setPrevLinks(pageNr);
        $(this.dom).find(".paged-control-current").first().text(pageNr);
        this.setNextLinks(pageNr);

        if (pageNr == this.pageCount)
            $(this.dom).find(".paged-control-last").hide(0);
        else
            $(this.dom).find(".paged-control-last").show(0);
    };
}