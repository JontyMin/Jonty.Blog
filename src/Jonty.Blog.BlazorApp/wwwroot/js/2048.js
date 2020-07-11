﻿function KeyboardInputManager() {
    this.events = {};
    window.navigator.msPointerEnabled ? (this.eventTouchstart = "MSPointerDown", this.eventTouchmove = "MSPointerMove",
        this.eventTouchend = "MSPointerUp") : (this.eventTouchstart = "touchstart", this.eventTouchmove =
            "touchmove", this.eventTouchend = "touchend");
    this.listen()
}
function HTMLActuator() {
    this.tileContainer = document.querySelector(".tile-container");
    this.scoreContainer = document.querySelector(".score-container");
    this.bestContainer = document.querySelector(".best-container");
    this.messageContainer = document.querySelector(".game-message");
    this.sharingContainer = document.querySelector(".score-sharing");
    this.score = 0
}
function Grid(n, t) {
    this.size = n;
    this.cells = t ? this.fromState(t) : this.empty()
}
function Tile(n, t) {
    this.x = n.x;
    this.y = n.y;
    this.value = t || 2;
    this.previousPosition = null;
    this.mergedFrom = null
}
function LocalStorageManager() {
    this.bestScoreKey = "bestScore";
    this.gameStateKey = "gameState";
    var n = this.localStorageSupported();
    this.storage = n ? window.localStorage : window.fakeStorage
}
function GameManager(n, t, i, r) {
    this.size = n;
    this.inputManager = new t;
    this.storageManager = new r;
    this.actuator = new i;
    this.startTiles = 2;
    this.inputManager.on("move", this.move.bind(this));
    this.inputManager.on("restart", this.restart.bind(this));
    this.inputManager.on("keepPlaying", this.keepPlaying.bind(this));
    this.setup()
}
Function.prototype.bind = Function.prototype.bind || function (n) {
    var t = this;
    return function (i) {
        i instanceof Array || (i = [i]);
        t.apply(n, i)
    }
},
    function () {
        function t(n) {
            var r, t;
            for (this.el = n, r = n.className.replace(/^\s+|\s+$/g, "").split(/\s+/), t = 0; t < r.length; t++) i.call(
                this, r[t])
        }
        function f(n, t, i) {
            Object.defineProperty ? Object.defineProperty(n, t, {
                get: i
            }) : n.__defineGetter__(t, i)
        }
        if (typeof Element != "undefined" && !("classList" in document.documentElement)) {
            var n = Array.prototype,
                i = n.push,
                r = n.splice,
                u = n.join;
            t.prototype = {
                add: function (n) {
                    this.contains(n) || (i.call(this, n), this.el.className = this.toString())
                },
                contains: function (n) {
                    return this.el.className.indexOf(n) != -1
                },
                item: function (n) {
                    return this[n] || null
                },
                remove: function (n) {
                    if (this.contains(n)) {
                        for (var t = 0; t < this.length; t++)
                            if (this[t] == n) break;
                        r.call(this, t, 1);
                        this.el.className = this.toString()
                    }
                },
                toString: function () {
                    return u.call(this, " ")
                },
                toggle: function (n) {
                    return this.contains(n) ? this.remove(n) : this.add(n), this.contains(n)
                }
            };
            window.DOMTokenList = t;
            f(HTMLElement.prototype, "classList", function () {
                return new t(this)
            })
        }
    }(),
    function () {
        for (var i = 0, t = ["webkit", "moz"], n = 0; n < t.length && !window.requestAnimationFrame; ++n) window.requestAnimationFrame =
            window[t[n] + "RequestAnimationFrame"], window.cancelAnimationFrame = window[t[n] + "CancelAnimationFrame"] ||
            window[t[n] + "CancelRequestAnimationFrame"];
        window.requestAnimationFrame || (window.requestAnimationFrame = function (n) {
            var t = (new Date).getTime(),
                r = Math.max(0, 16 - (t - i)),
                u = window.setTimeout(function () {
                    n(t + r)
                }, r);
            return i = t + r, u
        });
        window.cancelAnimationFrame || (window.cancelAnimationFrame = function (n) {
            clearTimeout(n)
        })
    }();
KeyboardInputManager.prototype.on = function (n, t) {
    this.events[n] || (this.events[n] = []);
    this.events[n].push(t)
};
KeyboardInputManager.prototype.emit = function (n, t) {
    var i = this.events[n];
    i && i.forEach(function (n) {
        n(t)
    })
};
KeyboardInputManager.prototype.listen = function () {
    var n = this,
        u = {
            38: 0,
            39: 1,
            40: 2,
            37: 3,
            75: 0,
            76: 1,
            74: 2,
            72: 3,
            87: 0,
            68: 1,
            83: 2,
            65: 3
        },
        i, r, t;
    document.addEventListener("keydown", function (t) {
        var i = t.altKey || t.ctrlKey || t.metaKey || t.shiftKey,
            r = u[t.which];
        n.targetIsInput(t) || (i || r !== undefined && (t.preventDefault(), n.emit("move", r)), i || t.which !==
            82 || n.restart.call(n, t))
    });
    this.bindButtonPress(".retry-button", this.restart);
    this.bindButtonPress(".restart-button", this.restart);
    this.bindButtonPress(".keep-playing-button", this.keepPlaying);
    t = document.getElementsByClassName("game-container")[0];
    t.addEventListener(this.eventTouchstart, function (t) {
        !window.navigator.msPointerEnabled && t.touches.length > 1 || t.targetTouches > 1 || n.targetIsInput(
            t) || (window.navigator.msPointerEnabled ? (i = t.pageX, r = t.pageY) : (i = t.touches[0].clientX,
                r = t.touches[0].clientY), t.preventDefault())
    });
    t.addEventListener(this.eventTouchmove, function (n) {
        n.preventDefault()
    });
    t.addEventListener(this.eventTouchend, function (t) {
        var u, f;
        if ((window.navigator.msPointerEnabled || !(t.touches.length > 0)) && !(t.targetTouches > 0) && !n.targetIsInput(
            t)) {
            window.navigator.msPointerEnabled ? (u = t.pageX, f = t.pageY) : (u = t.changedTouches[0].clientX,
                f = t.changedTouches[0].clientY);
            var e = u - i,
                o = Math.abs(e),
                s = f - r,
                h = Math.abs(s);
            Math.max(o, h) > 10 && n.emit("move", o > h ? e > 0 ? 1 : 3 : s > 0 ? 2 : 0)
        }
    })
};
KeyboardInputManager.prototype.restart = function (n) {
    n.preventDefault();
    this.emit("restart")
};
KeyboardInputManager.prototype.keepPlaying = function (n) {
    n.preventDefault();
    this.emit("keepPlaying")
};
KeyboardInputManager.prototype.bindButtonPress = function (n, t) {
    var i = document.querySelector(n);
    i.addEventListener("click", t.bind(this));
    i.addEventListener(this.eventTouchend, t.bind(this))
};
KeyboardInputManager.prototype.targetIsInput = function (n) {
    return n.target.tagName.toLowerCase() === "input"
};
HTMLActuator.prototype.actuate = function (n, t) {
    var i = this;
    window.requestAnimationFrame(function () {
        i.clearContainer(i.tileContainer);
        n.cells.forEach(function (n) {
            n.forEach(function (n) {
                n && i.addTile(n)
            })
        });
        i.updateScore(t.score);
        i.updateBestScore(t.bestScore);
        t.terminated && (t.over ? i.message(!1) : t.won && i.message(!0))
    })
};
HTMLActuator.prototype.continueGame = function () {
    typeof ga != "undefined" && ga("send", "event", "game", "restart");
    this.clearMessage()
};
HTMLActuator.prototype.clearContainer = function (n) {
    while (n.firstChild) n.removeChild(n.firstChild)
};
//HTMLActuator.prototype.tileHTML = ["菜鸟", "入门", "码畜", "码奴", "码农", "IT民工", "IT工程师", "IT人才", "IT精英", "IT大哥", "IT领袖"];
HTMLActuator.prototype.tileHTML = ["菜鸟", "入门", "码畜", "码奴", "码农", "初级开发", "中级开发", "高级开发", "资深开发", "技术专家", "神🤣"];
HTMLActuator.prototype.addTile = function (n) {
    var r = this,
        i = document.createElement("div"),
        u = document.createElement("div"),
        f = n.previousPosition || {
            x: n.x,
            y: n.y
        },
        e = this.positionClass(f),
        t = ["tile", "tile-" + n.value, e];
    n.value > 2048 && t.push("tile-super");
    this.applyClasses(i, t);
    u.classList.add("tile-inner");
    u.textContent = HTMLActuator.prototype.tileHTML[Math.log(n.value) / Math.LN2 - 1] || n.value;
    n.previousPosition ? window.requestAnimationFrame(function () {
        t[2] = r.positionClass({
            x: n.x,
            y: n.y
        });
        r.applyClasses(i, t)
    }) : n.mergedFrom ? (t.push("tile-merged"), this.applyClasses(i, t), n.mergedFrom.forEach(function (n) {
        r.addTile(n)
    })) : (t.push("tile-new"), this.applyClasses(i, t));
    i.appendChild(u);
    this.tileContainer.appendChild(i)
};
HTMLActuator.prototype.applyClasses = function (n, t) {
    n.setAttribute("class", t.join(" "))
};
HTMLActuator.prototype.normalizePosition = function (n) {
    return {
        x: n.x + 1,
        y: n.y + 1
    }
};
HTMLActuator.prototype.positionClass = function (n) {
    return n = this.normalizePosition(n), "tile-position-" + n.x + "-" + n.y
};
HTMLActuator.prototype.updateScore = function (n) {
    var i, t;
    this.clearContainer(this.scoreContainer);
    i = n - this.score;
    this.score = n;
    this.scoreContainer.textContent = this.score;
    i > 0 && (t = document.createElement("div"), t.classList.add("score-addition"), t.textContent = "+" + i, this.scoreContainer
        .appendChild(t))
};
HTMLActuator.prototype.updateBestScore = function (n) {
    this.bestContainer.textContent = n
};
HTMLActuator.prototype.message = function (n) {
    var t = n ? "game-won" : "game-over",
        i = n ? "You win!" : "Game over!";
    typeof ga != "undefined" && ga("send", "event", "game", "end", t, this.score);
    this.messageContainer.classList.add(t);
    this.messageContainer.getElementsByTagName("p")[0].textContent = i;
    this.clearContainer(this.sharingContainer);
};
HTMLActuator.prototype.clearMessage = function () {
    this.messageContainer.classList.remove("game-won");
    this.messageContainer.classList.remove("game-over")
};
Grid.prototype.empty = function () {
    for (var r, t, i = [], n = 0; n < this.size; n++)
        for (r = i[n] = [], t = 0; t < this.size; t++) r.push(null);
    return i
};
Grid.prototype.fromState = function (n) {
    for (var f, i, r, u = [], t = 0; t < this.size; t++)
        for (f = u[t] = [], i = 0; i < this.size; i++) r = n[t][i], f.push(r ? new Tile(r.position, r.value) : null);
    return u
};
Grid.prototype.randomAvailableCell = function () {
    var n = this.availableCells();
    if (n.length) return n[Math.floor(Math.random() * n.length)]
};
Grid.prototype.availableCells = function () {
    var n = [];
    return this.eachCell(function (t, i, r) {
        r || n.push({
            x: t,
            y: i
        })
    }), n
};
Grid.prototype.eachCell = function (n) {
    for (var i, t = 0; t < this.size; t++)
        for (i = 0; i < this.size; i++) n(t, i, this.cells[t][i])
};
Grid.prototype.cellsAvailable = function () {
    return !!this.availableCells().length
};
Grid.prototype.cellAvailable = function (n) {
    return !this.cellOccupied(n)
};
Grid.prototype.cellOccupied = function (n) {
    return !!this.cellContent(n)
};
Grid.prototype.cellContent = function (n) {
    return this.withinBounds(n) ? this.cells[n.x][n.y] : null
};
Grid.prototype.insertTile = function (n) {
    this.cells[n.x][n.y] = n
};
Grid.prototype.removeTile = function (n) {
    this.cells[n.x][n.y] = null
};
Grid.prototype.withinBounds = function (n) {
    return n.x >= 0 && n.x < this.size && n.y >= 0 && n.y < this.size
};
Grid.prototype.serialize = function () {
    for (var r, t, i = [], n = 0; n < this.size; n++)
        for (r = i[n] = [], t = 0; t < this.size; t++) r.push(this.cells[n][t] ? this.cells[n][t].serialize() :
            null);
    return {
        size: this.size,
        cells: i
    }
};
Tile.prototype.savePosition = function () {
    this.previousPosition = {
        x: this.x,
        y: this.y
    }
};
Tile.prototype.updatePosition = function (n) {
    this.x = n.x;
    this.y = n.y
};
Tile.prototype.serialize = function () {
    return {
        position: {
            x: this.x,
            y: this.y
        },
        value: this.value
    }
};
window.fakeStorage = {
    _data: {},
    setItem: function (n, t) {
        return this._data[n] = String(t)
    },
    getItem: function (n) {
        return this._data.hasOwnProperty(n) ? this._data[n] : undefined
    },
    removeItem: function (n) {
        return delete this._data[n]
    },
    clear: function () {
        return this._data = {}
    }
};
LocalStorageManager.prototype.localStorageSupported = function () {
    var n = "test",
        t = window.localStorage;
    try {
        return t.setItem(n, "1"), t.removeItem(n), !0
    } catch (i) {
        return !1
    }
};
LocalStorageManager.prototype.getBestScore = function () {
    return this.storage.getItem(this.bestScoreKey) || 0
};
LocalStorageManager.prototype.setBestScore = function (n) {
    this.storage.setItem(this.bestScoreKey, n)
};
LocalStorageManager.prototype.getGameState = function () {
    var n = this.storage.getItem(this.gameStateKey);
    return n ? JSON.parse(n) : null
};
LocalStorageManager.prototype.setGameState = function (n) {
    this.storage.setItem(this.gameStateKey, JSON.stringify(n))
};
LocalStorageManager.prototype.clearGameState = function () {
    this.storage.removeItem(this.gameStateKey)
};
GameManager.prototype.restart = function () {
    this.storageManager.clearGameState();
    this.actuator.continueGame();
    this.setup()
};
GameManager.prototype.keepPlaying = function () {
    this.keepPlaying = !0;
    this.actuator.continueGame()
};
GameManager.prototype.isGameTerminated = function () {
    return this.over || this.won && !this.keepPlaying ? !0 : !1
};
GameManager.prototype.setup = function () {
    var n = this.storageManager.getGameState();
    n ? (this.grid = new Grid(n.grid.size, n.grid.cells), this.score = n.score, this.over = n.over, this.won = n.won,
        this.keepPlaying = n.keepPlaying) : (this.grid = new Grid(this.size), this.score = 0, this.over = !1,
            this.won = !1, this.keepPlaying = !1, this.addStartTiles());
    this.actuate()
};
GameManager.prototype.addStartTiles = function () {
    for (var n = 0; n < this.startTiles; n++) this.addRandomTile()
};
GameManager.prototype.addRandomTile = function () {
    if (this.grid.cellsAvailable()) {
        var n = Math.random() < .9 ? 2 : 4,
            t = new Tile(this.grid.randomAvailableCell(), n);
        this.grid.insertTile(t)
    }
};
GameManager.prototype.actuate = function () {
    this.storageManager.getBestScore() < this.score && this.storageManager.setBestScore(this.score);
    this.over ? this.storageManager.clearGameState() : this.storageManager.setGameState(this.serialize());
    this.actuator.actuate(this.grid, {
        score: this.score,
        over: this.over,
        won: this.won,
        bestScore: this.storageManager.getBestScore(),
        terminated: this.isGameTerminated()
    })
};
GameManager.prototype.serialize = function () {
    return {
        grid: this.grid.serialize(),
        score: this.score,
        over: this.over,
        won: this.won,
        keepPlaying: this.keepPlaying
    }
};
GameManager.prototype.prepareTiles = function () {
    this.grid.eachCell(function (n, t, i) {
        i && (i.mergedFrom = null, i.savePosition())
    })
};
GameManager.prototype.moveTile = function (n, t) {
    this.grid.cells[n.x][n.y] = null;
    this.grid.cells[t.x][t.y] = n;
    n.updatePosition(t)
};
GameManager.prototype.move = function (n) {
    var t = this;
    if (!this.isGameTerminated()) {
        var r, i, u = this.getVector(n),
            f = this.buildTraversals(u),
            e = !1;
        this.prepareTiles();
        f.x.forEach(function (n) {
            f.y.forEach(function (f) {
                var o, s, h;
                r = {
                    x: n,
                    y: f
                };
                i = t.grid.cellContent(r);
                i && (o = t.findFarthestPosition(r, u), s = t.grid.cellContent(o.next), s && s.value ===
                    i.value && !s.mergedFrom ? (h = new Tile(o.next, i.value * 2), h.mergedFrom = [
                        i, s], t.grid.insertTile(h), t.grid.removeTile(i), i.updatePosition(
                            o.next), t.score += h.value, h.value === 2048 && (t.won = !0)) : t.moveTile(
                                i, o.farthest), t.positionsEqual(r, i) || (e = !0))
            })
        });
        e && (this.addRandomTile(), this.movesAvailable() || (this.over = !0), this.actuate())
    }
};
GameManager.prototype.getVector = function (n) {
    return {
        0: {
            x: 0,
            y: -1
        },
        1: {
            x: 1,
            y: 0
        },
        2: {
            x: 0,
            y: 1
        },
        3: {
            x: -1,
            y: 0
        }
    }[n]
};
GameManager.prototype.buildTraversals = function (n) {
    for (var t = {
        x: [],
        y: []
    }, i = 0; i < this.size; i++) t.x.push(i), t.y.push(i);
    return n.x === 1 && (t.x = t.x.reverse()), n.y === 1 && (t.y = t.y.reverse()), t
};
GameManager.prototype.findFarthestPosition = function (n, t) {
    var i;
    do i = n, n = {
        x: i.x + t.x,
        y: i.y + t.y
    }; while (this.grid.withinBounds(n) && this.grid.cellAvailable(n));
    return {
        farthest: i,
        next: n
    }
};
GameManager.prototype.movesAvailable = function () {
    return this.grid.cellsAvailable() || this.tileMatchesAvailable()
};
GameManager.prototype.tileMatchesAvailable = function () {
    for (var n, i, u = this, r, t = 0; t < this.size; t++)
        for (n = 0; n < this.size; n++)
            if (r = this.grid.cellContent({
                x: t,
                y: n
            }), r)
                for (i = 0; i < 4; i++) {
                    var f = u.getVector(i),
                        o = {
                            x: t + f.x,
                            y: n + f.y
                        },
                        e = u.grid.cellContent(o);
                    if (e && e.value === r.value) return !0
                }
    return !1
};
GameManager.prototype.positionsEqual = function (n, t) {
    return n.x === t.x && n.y === t.y
};
window.requestAnimationFrame(function () {
    new GameManager(4, KeyboardInputManager, HTMLActuator, LocalStorageManager)
});