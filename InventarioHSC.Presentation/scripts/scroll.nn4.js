// Title: Tigra Scroller PRO
// URL: http://www.softcomplex.com/products/tigra_scroller_pro/
// Version: 1.5 (size optimized)
// Date: 06-25-2003 (mm-dd-yyyy)
// Technical Support: support@softcomplex.com (specify product title and order ID)
// Notes: Registration needed to use this script legally.
//	Visit official site for details.
// ----------------------------------------
function TSB(w, h, vertical, TSC, TSD) {
    var i, m = 0,
        TSE = 0,
        TSF = '<ilayer>',
        TSG = this.TSG,
        TSH = this.hide_buttons ? "hide" : "show",
        TSI = vertical ? w : this.distance,
        TSJ = vertical ? this.distance : h,
        TSK = [];
    for (i in TSA.TSL) TSK[i] = TSA.TSL[i] + this.id;
    this.TSM = 'hide';
    this.TSN = 'show';
    this.TSR = document;
    this.TSP = function (n) {
        return this.TSa.document.images['TScr' + this.id + 'i' + n][vertical ? 'y' : 'x']
    };
    this.TSS = function (n, d) {
        var i, x;
        if (!d) d = document;
        x = d['TScr_' + n + this.id];
        for (i = 0; !x && d.layers && i < d.layers.length; i++) x = this.TSS(n, d.layers[i].document);
        return x
    };
    this.TST = vertical ?
    function () {
        this.TSa.top = this.TSX;
        this.TSa.clip.top = -this.TSX;
        this.TSa.clip.bottom = h - this.TSX
    } : function () {
        this.TSa.left = this.TSX;
        this.TSa.clip.left = -this.TSX;
        this.TSa.clip.right = w - this.TSX
    };
    if (this.auto) {
        var TSb = new Image(TSC.pa[2], TSC.pa[3]),
            TSc = new Image(TSC.re[2], TSC.re[3]),
            TSd = new Image(TSC.nx[2], TSC.nx[3]),
            TSe = new Image(TSC.pr[2], TSC.pr[3]);
        TSb.src = TSC.pa[4] ? TSC.pa[4] : TSA.pa[4];
        TSc.src = TSC.re[4] ? TSC.re[4] : TSA.re[4];
        TSd.src = TSC.nx[4] ? TSC.nx[4] : TSA.nx[4];
        TSe.src = TSC.pr[4] ? TSC.pr[4] : TSA.pr[4];
        TSF += '<layer name=TScr_pau' + this.id + ' visibility=' + TSH + ' z-index=2 left=' + TSC.pa[0] + ' top=' + TSC.pa[1] + ' onmouseover="TScroll[' + this.id + '].TSAD()" onmouseout="TScroll[' + this.id + '].TSAC()"><a href="javascript:TScroll[' + this.id + '].TSAE()"><img src=' + TSb.src + ' width=' + TSC.pa[2] + ' height=' + TSC.pa[3] + ' alt="pause scrolling" border=0></a></layer><layer name=TScr_res' + this.id + ' visibility=hide z-index=2 left=' + TSC.re[0] + ' top=' + TSC.re[1] + ' onmouseover="TScroll[' + this.id + '].TSAD()" onmouseout="TScroll[' + this.id + '].TSAC()"><a href="javascript:TScroll[' + this.id + '].TSAF()"><img src=' + TSc.src + ' width=' + TSC.re[2] + ' height=' + TSC.re[3] + ' alt="resume scrolling" border=0></a></layer><layer name=TScr_nxt' + this.id + ' visibility=' + TSH + ' z-index=2 left=' + TSC.nx[0] + ' top=' + TSC.nx[1] + ' onmouseover="TScroll[' + this.id + '].TSAD()" onmouseout="TScroll[' + this.id + '].TSAC()"><a href="javascript:TScroll[' + this.id + '].click_pass(1)"><img src=' + TSd.src + ' width=' + TSC.nx[2] + ' height=' + TSC.nx[3] + ' alt="next item" border=0></a></layer><layer name=TScr_prv' + this.id + ' visibility=' + TSH + ' z-index=2 left=' + TSC.pr[0] + ' top=' + TSC.pr[1] + ' onmouseover="TScroll[' + this.id + '].TSAD()" onmouseout="TScroll[' + this.id + '].TSAC()"><a href="javascript:TScroll[' + this.id + '].click_pass(-1)"><img src=' + TSe.src + ' width=' + TSC.pr[2] + ' height=' + TSC.pr[3] + ' alt="previous item" border=0></a></layer>'
    } else {
        var TSf = new Image(TSC.up[2], TSC.up[3]),
            TSg = new Image(TSC.dn[2], TSC.dn[3]);
        TSf.src = TSC.up[4] ? TSC.up[4] : TSA.up[4];
        TSg.src = TSC.dn[4] ? TSC.dn[4] : TSA.dn[4];
        TSF += '<layer name=TScr_aup' + this.id + ' z-index=2 left=' + TSC.up[0] + ' top=' + TSC.up[1] + ' visibility=' + TSH + ' onmouseover="TScroll[' + this.id + '].TSAI()" onmouseout="TScroll[' + this.id + '].TSAH()"><img src=' + TSf.src + ' width=' + TSC.up[2] + ' height=' + TSC.up[3] + ' border=0></layer>' + '<layer name=TScr_adn' + this.id + ' z-index=2 left=' + TSC.dn[0] + ' top=' + TSC.dn[1] + ' visibility=' + TSH + ' onmouseover="TScroll[' + this.id + '].TSAJ()" onmouseout="TScroll[' + this.id + '].TSAG()"><img src=' + TSg.src + ' width=' + TSC.dn[2] + ' height=' + TSC.dn[3] + ' border=0></layer>'
    }
    TSF += '<layer name=TScr_main' + this.id + (vertical ? ' top=' + this.TSX + ' clip=0,' + (-this.TSX) + ',' + w + ',' + (h - this.TSX) : ' left=' + this.TSX + ' clip=' + (-this.TSX) + ',0,' + (w - this.TSX) + ',' + h) + ' z-index=0';
    if (this.auto || this.hide_buttons) TSF += ' onmouseover="TScroll[' + this.id + '].TSAD()" onmouseout="TScroll[' + this.id + '].TSAC()"';
    TSF += '><table class=' + TSK.TSh + ' cellpadding=0 cellspacing=0 border=0><tr>';
    for (i in TSD) if (TSD[i].content) {
        this.TSV[m] = {
            'TSAB': [TSD[i].pause_b, TSD[i].pause_a]
        };
        TSF += '<td><img name="TScr' + this.id + 'i' + m + '" src=' + TSA.TSj + ' width=' + TSI + ' height=' + TSJ + '></td>';
        TSF += vertical ? '</tr><tr>' : '<td valign="top" width=' + w + '><table cellpadding=0 cellspacing=0 border=0><tr>';
        TSF += '<td valign="top"><span class=' + TSK.TSk + '>' + TSD[i].content + '</span></td></tr><tr>';
        if (!vertical && TSG) TSF += '<td><img src=' + TSA.TSj + ' width=' + TSG + ' height=1></td></tr></table></td>';
        m++
    }
    i = 0;
    do if (TSD[i].content) {
        TSE += this.distance;
        TSF += '<td><img name="TScr' + this.id + 'i' + m + '" src=' + TSA.TSj + ' width=' + TSI + ' height=' + TSJ + '></td>';
        TSF += vertical ? '</tr><tr>' : '<td valign="top" width=' + w + '><table cellpadding=0 cellspacing=0 border=0><tr>';
        TSF += '<td valign="top"><span class=' + TSK.TSk + '>' + TSD[i].content + '</span></td></tr><tr>';
        if (!vertical && TSG) TSF += '<td><img src=' + TSA.TSj + ' width=' + TSG + ' height=1></td></tr></table></td>';
        m++;
        if (++i == TSD.length) i = 0
    }
    while (TSE <= this.height);
    TSF += '</tr></table></layer></ilayer>';
    document.write(TSF);
    this.TSt()
}