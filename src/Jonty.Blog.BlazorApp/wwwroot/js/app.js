﻿var func = window.func || {}, editor;

(function (l) {
    if (l.search) {
        var q = {};
        l.search.slice(1).split('&').forEach(function (v) {
            var a = v.split('=');
            q[a[0]] = a.slice(1).join('=').replace(/~and~/g, '&');
        });
        if (q.p !== undefined) {
            window.history.replaceState(null, null,
                l.pathname.slice(0, -1) + (q.p || '') +
                (q.q ? ('?' + q.q) : '') +
                l.hash
            );
        }
    }
}(window.location));

func = {
    setStorage: function (name, value) {
        localStorage.setItem(name, value);
    },
    getStorage: function (name) {
        return localStorage.getItem(name);
    },
    switchTheme: function () {
        var currentTheme = this.getStorage('theme') || 'Light';
        var isDark = currentTheme === 'Dark';

        if (isDark) {
            document.querySelector('body').classList.add('dark-theme');
        } else {
            document.querySelector('body').classList.remove('dark-theme');
        }
    },
    switchEditorTheme: function () {
        editor.setTheme(localStorage.editorTheme || 'default');
        editor.setEditorTheme(localStorage.editorTheme === 'dark' ? 'pastel-on-dark' : 'default');
        editor.setPreviewTheme(localStorage.editorTheme || 'default');
    },
    renderEditor: async function () {
        await this._loadScript('./editor.md/lib/zepto.min.js').then(function () {
            func._loadScript('./editor.md/editormd.js').then(function () {
                editor = editormd("editor", {
                    width: "100%",
                    height: 700,
                    path: './editor.md/lib/',
                    codeFold: true,
                    saveHTMLToTextarea: true,
                    emoji: true,
                    atLink: false,
                    emailLink: false,
                    theme: localStorage.editorTheme || 'default',
                    editorTheme: localStorage.editorTheme === 'dark' ? 'pastel-on-dark' : 'default',
                    previewTheme: localStorage.editorTheme || 'default',
                    toolbarIcons: function () {
                        return ["bold", "del", "italic", "quote", "ucwords", "uppercase", "lowercase", "h1", "h2", "h3", "h4", "h5", "h6", "list-ul", "list-ol", "hr", "link", "image", "code", "preformatted-text", "code-block", "table", "datetime", "html-entities", "emoji", "watch", "preview", "fullscreen", "clear", "||", "save"]
                    },
                    toolbarIconsClass: {
                        save: "fa-check"
                    },
                    toolbarHandlers: {
                        save: function () {
                            func._shoowBox();
                        }
                    },
                    onload: function () {
                        this.addKeyMap({
                            "Ctrl-S": function () {
                                func._shoowBox();
                            }
                        });
                    }
                });
            });
        });
    },
    renderMarkdown: async function () {
        await this._loadScript('./editor.md/lib/zepto.min.js').then(function () {
            func._loadScript('./editor.md/lib/marked.min.js').then(function () {
                func._loadScript('./editor.md/lib/prettify.min.js').then(function () {
                    func._loadScript('./editor.md/editormd.js').then(function () {
                        editormd.markdownToHTML("content");
                    });
                });
            });
        });
    },
    render2048Game: async function () {
	    await this._loadScript('./js/2048.js');
    },
    disableKey() {
	    document.body.oncontextmenu = function () {
		    self.event.returnValue = false;
	    };
	    document.onkeydown = function () {
		    if (event.ctrlKey && window.event.keyCode == 85) {
			    return false;
		    }
		    if (event.ctrlKey && event.shiftKey && window.event.keyCode == 73) {
			    return false;
		    }
		    if (window.event && window.event.keyCode == 123) {
			    event.keyCode = 0;
			    event.returnValue = false;
		    }
	    }
    },
    openBlobWallpaper(src) {
	    fetch(src.replace("middle", "max")).then(res => res.blob().then(blob => {
		    window.open(window.URL.createObjectURL(blob), "_blank");
	    }));
    },
    _shoowBox: function () {
        DotNet.invokeMethodAsync('Jonty.Blog.BlazorApp', 'showbox');
    },
    _loadScript: async function (url) {
        let response = await fetch(url);
        var js = await response.text();
        eval(js);
    }
};