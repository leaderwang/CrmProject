/*************************自定义函数*********************************/
var UrlEncode;
UrlEncode = function (str) {
    return encodeURIComponent(str).replace(/!/g, '%21').replace(/'/g, '%27').replace(/\(/g, '%28').replace(/\)/g, '%29').replace(/\*/g, '%2A').replace(/%20/g, '+');
};

var wx_key = '7ce2048d61ad391a';
var wx_secret = '6CE64075D0DBC8D1B8D6AE04D39B9010';
var wx_debug = false;
var wx_backurl = UrlEncode(window.location.href);
var wx_domain = 'http://wx.vhdong.com';
var wx_openid = $("#openid").val();

//document.write('<script type="text/javascript" src="/Areas/Mobile/Content/js/jweixin-1.0.0.js"><\/script>');
document.write('<script type="text/javascript" src="https://res.wx.qq.com/open/js/jweixin-1.0.0.js"><\/script>');
document.write('<script type="text/javascript" src="' + wx_domain + '/api/jswxconfig?key=' + wx_key + '&secret=' + wx_secret + '&debug=' + wx_debug + '&url=' + wx_backurl + ' "><\/script>');


/******************微信标准代码（请勿修改）*************************/
/* 上传单张图片 */
function wxsolaupload(callback) {
    chooseImage(function (res) {
        var localIds = res.localIds.toString();
        if (localIds.indexOf(",") != -1) {
            layer.alert("请选择一张图片", 3);
            return;
        };
        wx.uploadImage({
            localId: localIds,
            isShowProgressTips: 1,
            success: function (resoure) {
                callback(resoure.serverId);
            },
            fail: function (resoure) {
                layer.alert(JSON.stringify(resoure));
            }
        });
    });
}

/* 上传多张图片 */
function wxmultiupload(callback) {
    chooseImage(function (res) {
        //var _layer = layer.load('正在加载...', 999999);
        var localIds = res.localIds.toString().split(",");
        if (localIds.length > 0) {
            var uploadId = [];
            var i = 0;

            function upload() {
                wx.uploadImage({
                    localId: localIds[i],
                    isShowProgressTips: 1,
                    success: function (resoure) {
                        uploadId.push(resoure.serverId);
                        i++;
                        if (i < localIds.length) {
                            upload();
                        } else {
                            callback(uploadId, localIds);
                        }
                    },
                    fail: function (resoure) {
                        layer.alert(JSON.stringify(resoure));
                    }
                });
            };

            upload();
        };
        //layer.close(_layer);
    });
}


/* 隐藏右上角菜单接口 */
function hideOptionMenu() {
    if (typeof wx == "undefined") return false;

    wx.hideOptionMenu();
}

/* 显示右上角菜单接口 */
function showOptionMenu() {
    if (typeof wx == "undefined") return false;

    wx.showOptionMenu();
}

/* 关闭当前网页窗口接口 */
function closeWindow() {
    if (typeof wx == "undefined") {
        window.close();
    } else {
        wx.closeWindow();
    }
}

/* 批量隐藏功能按钮接口 */
function hideMenuItems(array) {
    if (typeof wx == "undefined") return false;

    wx.hideMenuItems({
        menuList: array // 要隐藏的菜单项，所有menu项见附录3
    });
}

/* 批量显示功能按钮接口 */
function showMenuItems(array) {
    if (typeof wx == "undefined") return false;

    wx.showMenuItems({
        menuList: array // 要显示的菜单项，所有menu项见附录3
    });
}

/* 隐藏所有非基础按钮接口 */
function hideAllNonBaseMenuItem() {
    if (typeof wx == "undefined") return false;

    wx.hideAllNonBaseMenuItem();
}

/* 显示所有功能按钮接口 */
function showAllNonBaseMenuItem() {
    if (typeof wx == "undefined") return false;

    wx.showAllNonBaseMenuItem();
}

/* 获取网络状态接口 */
/* 返回网络类型2g，3g，4g，wifi */
function getNetworkType() {
    if (typeof wx == "undefined") return false;

    wx.getNetworkType({
        success: function (res) {
            return res.networkType;
        }
    });
}

/* 拍照或从手机相册中选图接口 */
/* 返回选定照片的本地ID列表，localIds可以作为img标签的src属性显示图片 */
function chooseImage(callback) {
    if (typeof wx == "undefined") return false;
    wx.chooseImage({
        success: function (res) {
            callback(res);
            // var localIds = res.localIds;
        }
    });
}

/* 上传图片接口 */
/* localId: 需要上传的图片的本地ID，由chooseImage接口获得 */
/* isShowProgressTips: 默认为1，显示进度提示 */
/* serverId: 返回图片的服务器端ID */
/* 返回图片的服务器端ID */
function uploadImage(localId, isShowProgressTips) {
    if (typeof wx == "undefined") return false;

    wx.uploadImage({
        localId: localId,
        isShowProgressTips: isShowProgressTips,
        success: function (res) {
            var serverId = res.serverId;
        }
    });
}

/* 预览图片接口 */
/* current: 当前显示的图片链接 */
/* urls: 需要预览的图片链接列表 */
function previewImage(current, urls) {
    if (typeof wx == "undefined") return false;

    wx.previewImage({
        current: current,
        urls: urls
    });
}

/* 验证是否为远程地址 */
function isRemoteURL(url) {
    var strRegex = "^((https|http)?://)";
    var re = new RegExp(strRegex);
    return re.test(url);
}

function scanQRCode(need, callback) {
    wx.scanQRCode({
        needResult: need ? need : 0, // 默认为0，扫描结果由微信处理，1则直接返回扫描结果，
        scanType: ["qrCode", "barCode"], // 可以指定扫二维码还是一维码，默认二者都有
        success: function (res) {
            //var result = res.resultStr; // 当needResult 为 1 时，扫码返回的结果
            if (callback) callback(res);
        }, fail: function (resoure) {
            alert(JSON.stringify(resoure));
        }
    });
}

function share(o) {
    var a = o || {},
        t = document.title,
        h = location.href,
        d = new Date(),
        s = document.getElementsByTagName('img');

    var title = (a.title || t),
        desc = (a.desc || ''),
        link = (a.link || h),
        imgUrl = (a.imgUrl || "");

    //默认第一张图片
    if (!a.imgUrl && s.length > 0) a.imgUrl = s[0].src;
    //分享给朋友
    wx.onMenuShareAppMessage({
        title: title,// 分享标题
        desc: desc,// 分享描述
        link: link,// 分享链接
        imgUrl: imgUrl,// 分享图标
        success: function () {
            // 用户确认分享后执行的回调函数
            saveForwardIntegral(title, link, "发送给朋友");
            // layer.msg('感谢您的分享/转发！');
        },
        cancel: function () {
            // 用户取消分享后执行的回调函数
        }
    });
    //分享到朋友圈
    wx.onMenuShareTimeline({
        title: title,// 分享标题
        desc: desc,// 分享描述
        link: link,// 分享链接
        imgUrl: imgUrl,// 分享图标
        success: function () {
            // 用户确认分享后执行的回调函数
            saveForwardIntegral(title, link, "分享到朋友圈");
            //layer.msg('感谢您的分享/转发！');
        },
        cancel: function () {
            // 用户取消分享后执行的回调函数
        }
    });
    //分享到QQ
    wx.onMenuShareQQ({
        title: title,// 分享标题
        desc: desc,// 分享描述
        link: link,// 分享链接
        imgUrl: imgUrl,// 分享图标
        success: function () {
            // 用户确认分享后执行的回调函数
            saveForwardIntegral(title, link, "分享到手机QQ");
            //layer.msg('感谢您的分享/转发！');
        },
        cancel: function () {
            // 用户取消分享后执行的回调函数
        }
    });
    //分享到微博
    wx.onMenuShareWeibo({
        title: title,// 分享标题
        desc: desc,// 分享描述
        link: link,// 分享链接
        imgUrl: imgUrl,// 分享图标
        success: function () {
            // 用户确认分享后执行的回调函数
            saveForwardIntegral(title, link, "分享到微博");
            //layer.msg('感谢您的分享/转发！');
        },
        cancel: function () {
            // 用户取消分享后执行的回调函数
        }
    });
}

//获取url中的参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

function saveForwardIntegral(title, link, target) {
    $.ajax({
        type: 'POST',
        url: '/mobile/ajax/sharepaper',
        data: { openid: getUrlParam("openid"), title: title, link: link, target: target },
        success: function (d) {
        }
    });
}

//微信分享等按钮隐藏
//document.write("<script type='text/javascript'>wx.ready(function () { hideOptionMenu(); });<\/script>");
