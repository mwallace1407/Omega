// Title: Tigra Scroller PRO
// URL: http://www.softcomplex.com/products/tigra_scroller_pro/
// Version: 1.5 (size optimized)
// Date: 06-25-2003 (mm-dd-yyyy)
// Technical Support: support@softcomplex.com (specify product title and order ID)
// Notes: Registration needed to use this script legally.
//	Visit official site for details.
// ----------------------------------------
function TSB(w, h, vertical, TSC, TSD) {
    var i, k = 0,
        m = 0,
        TSE = 0,
        TSF, TSG = this.TSG,
        TSH = this.hide_buttons ? "hidden" : "visible",
        TSI = vertical ? w : this.distance,
        TSJ = vertical ? this.distance : h,
        TSK = [];
    for (i in TSA.TSL) TSK[i] = TSA.TSL[i] + this.id;
    this.TSM = 'hidden';
    this.TSN = 'visible';
    this.TSO = Boolean(document.body.style.filter != null);
    this.TSP = function (n) {
        function TSQ(img) {
            var x = img[vertical ? 'offsetTop' : 'offsetLeft'];
            if (img.offsetParent) x += TSQ(img.offsetParent);
            return x
        }
        return TSQ(this.TSR.images['i' + n]) + this.distance
    };
    this.TSS = function (n) {
        var x = this.TSR.getElementById(n);
        return x.style
    };
    this.TST = this.TSO ?
    function (TSU) {
        if (!TSU && this.t && this.TSV[this.t[1]].TSW) {
            var item = this.TSV[this.t[1]];
            this.TSX = -this.step / this.TSY * (this.distance - 1) - this.t[0];
            this.TSR.body.style.filter = item.TSW;
            try {
                this.TSR.body.filters[item.TSZ].apply()
            } catch (e) {} finally {}
        }
        this.TSa[vertical ? 'top' : 'left'] = this.TSX;
        if (item) {
            try {
                this.TSR.body.filters[item.TSZ].play()
            } catch (e) {} finally {};
            this.t = 0
        }
    } : function () {
        this.TSa[vertical ? 'top' : 'left'] = this.TSX
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
        TSF = ['<div id=pau style="position:absolute;visibility:', TSH, ';z-index:2;left:', TSC.pa[0], ';top:', TSC.pa[1], '"><a href="javascript:S.TSAE()" onmouseover="S.TSAD()" onmouseout="S.TSAC()"><img src=', TSb.src, ' width=', TSC.pa[2], ' height=', TSC.pa[3], ' alt="pause scrolling" border=0></a></div><div id=res style="position:absolute;visibility:hidden;z-index:2;left:', TSC.re[0], ';top:', TSC.re[1], '"><a href="javascript:S.TSAF()" onmouseover="S.TSAD()" onmouseout="S.TSAC()"><img src=', TSc.src, ' width=', TSC.re[2], ' height=', TSC.re[3], ' alt="resume scrolling" border=0></a></div><div id=nxt style="position:absolute;visibility:', TSH, ';z-index:2;left:', TSC.nx[0], ';top:', TSC.nx[1], '"><a href="javascript:S.click_pass(1)" onmouseover="S.TSAD()" onmouseout="S.TSAC()"><img src=', TSd.src, ' width=', TSC.nx[2], ' height=', TSC.nx[3], ' alt="next item" border=0></a></div><div id=prv style="position:absolute;visibility:', TSH, ';z-index:2;left:', TSC.pr[0], ';top:', TSC.pr[1], '"><a href="javascript:S.click_pass(-1)" onmouseover="S.TSAD()" onmouseout="S.TSAC()"><img src=', TSe.src, ' width=', TSC.pr[2], ' height=', TSC.pr[3], ' alt="previous item" border=0></a></div>'].join('')
    } else {
        var TSf = new Image(TSC.up[2], TSC.up[3]),
            TSg = new Image(TSC.dn[2], TSC.dn[3]);
        TSf.src = TSC.up[4] ? TSC.up[4] : TSA.up[4];
        TSg.src = TSC.dn[4] ? TSC.dn[4] : TSA.dn[4];
        TSF = ['<div id=aup style="position:absolute;z-index:2;left:', TSC.up[0], ';top:', TSC.up[1], ';visibility:', TSH, '" onmouseover="S.TSAI()" onmouseout="S.TSAH()"><img src=', TSf.src, ' width=', TSC.up[2], ' height=', TSC.up[3], ' border=0></div><div id=adn style="position:absolute;z-index:2;left:', TSC.dn[0], ';top:', TSC.dn[1], ';visibility:', TSH, '" onmouseover="S.TSAJ()" onmouseout="S.TSAG()"><img src=', TSg.src, ' width=', TSC.dn[2], ' height=', TSC.dn[3], ' border=0></div>'].join('')
    }
    TSF = [TSF, '<div id=main style="position:absolute;top:', vertical ? this.TSX + ';left:0' : '0;left:' + this.TSX, ';z-index:0"', this.auto || this.hide_buttons ? ' onmouseover="S.TSAD()" onmouseout="S.TSAC()"' : '', '><table class=', TSK.TSh, ' cellpadding=0 cellspacing=0 border=0><tr>'].join('');
    for (i in TSD) if ((TSD[i].file && document.body.innerHTML) || (!TSD[i].file && TSD[i].content) || (!document.body.innerHTML && TSD[i].content)) {
        this.TSV[m] = {
            'TSAB': [TSD[i].pause_b, TSD[i].pause_a]
        };
        this.TSV[m].TSW = this.TSO && TSD[i].transition && TSA.TSW[--TSD[i].transition[0]] ? (this.TSV[m].TSZ = TSA.TSW[TSD[i].transition[0]][0]) + "(duration=" + TSD[i].transition[1] + ",transition=" + TSA.TSW[TSD[i].transition[0]][1] + ")" : false;
        TSF += TSi(TSD[i]);
        m++
    }
    i = 0;
    do if ((TSD[i].file && document.body.innerHTML) || (!TSD[i].file && TSD[i].content) || (!document.body.innerHTML && TSD[i].content)) {
        TSE += this.distance;
        TSF += TSi(TSD[i]);
        m++;
        if (++i == TSD.length) i = 0
    }
    while (TSE <= this.height);
    this.TSF = TSF + '</tr></table></div>';
    document.write('<iframe src="' + TScroll_path_to_files + 'scroll.dom.html?' + this.id + '" frameborder="0" scrolling="No" width=' + w + ' height=' + h + '></iframe>');

    function TSi(item) {
        return ['<td><img name="i', m, '" src=', TSA.TSj, ' width=', TSI, ' height=', TSJ, '></td>', vertical ? '</tr><tr>' : '<td valign="top"><table cellpadding=0 cellspacing=0 border=0><tr>', '<td valign="top" class=', TSK.TSk, '>', item.file && document.body.innerHTML ? '<div id="d' + (k++) + '"></div><iframe style=visibility:hidden width=0 height=0 src="' + item.file + '"></iframe>' : item.content, '</td></tr><tr>', vertical || !TSG ? '' : '<td><img src=' + TSA.TSj + ' width=' + TSG + ' height=1></td></tr></table></td>'].join('')
    }
}