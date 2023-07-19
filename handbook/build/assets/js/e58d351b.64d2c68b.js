"use strict";(self.webpackChunkthingsgateway=self.webpackChunkthingsgateway||[]).push([[9708],{3905:(e,t,n)=>{n.d(t,{Zo:()=>c,kt:()=>m});var r=n(7294);function a(e,t,n){return t in e?Object.defineProperty(e,t,{value:n,enumerable:!0,configurable:!0,writable:!0}):e[t]=n,e}function o(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function l(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?o(Object(n),!0).forEach((function(t){a(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):o(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}function s(e,t){if(null==e)return{};var n,r,a=function(e,t){if(null==e)return{};var n,r,a={},o=Object.keys(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||(a[n]=e[n]);return a}(e,t);if(Object.getOwnPropertySymbols){var o=Object.getOwnPropertySymbols(e);for(r=0;r<o.length;r++)n=o[r],t.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(e,n)&&(a[n]=e[n])}return a}var i=r.createContext({}),p=function(e){var t=r.useContext(i),n=t;return e&&(n="function"==typeof e?e(t):l(l({},t),e)),n},c=function(e){var t=p(e.components);return r.createElement(i.Provider,{value:t},e.children)},u={inlineCode:"code",wrapper:function(e){var t=e.children;return r.createElement(r.Fragment,{},t)}},d=r.forwardRef((function(e,t){var n=e.components,a=e.mdxType,o=e.originalType,i=e.parentName,c=s(e,["components","mdxType","originalType","parentName"]),d=p(n),m=a,w=d["".concat(i,".").concat(m)]||d[m]||u[m]||o;return n?r.createElement(w,l(l({ref:t},c),{},{components:n})):r.createElement(w,l({ref:t},c))}));function m(e,t){var n=arguments,a=t&&t.mdxType;if("string"==typeof e||a){var o=n.length,l=new Array(o);l[0]=d;var s={};for(var i in t)hasOwnProperty.call(t,i)&&(s[i]=t[i]);s.originalType=e,s.mdxType="string"==typeof e?e:a,l[1]=s;for(var p=2;p<o;p++)l[p]=n[p];return r.createElement.apply(null,l)}return r.createElement.apply(null,n)}d.displayName="MDXCreateElement"},4201:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>i,contentTitle:()=>l,default:()=>u,frontMatter:()=>o,metadata:()=>s,toc:()=>p});var r=n(7462),a=(n(7294),n(3905));const o={id:"windowsrelease",title:"\u53d1\u5e03"},l=void 0,s={unversionedId:"windowsrelease",id:"windowsrelease",title:"\u53d1\u5e03",description:"\u4e00\u3001PM2\u5b88\u62a4",source:"@site/docs/windowsrelease.mdx",sourceDirName:".",slug:"/windowsrelease",permalink:"/thingsgateway-docs/docs/windowsrelease",draft:!1,editUrl:"https://gitee.com/diego2098/ThingsGateway/tree/master/handbook/docs/windowsrelease.mdx",tags:[],version:"current",lastUpdatedBy:"2248356998 qq.com",lastUpdatedAt:1689499706,formattedLastUpdatedAt:"Jul 16, 2023",frontMatter:{id:"windowsrelease",title:"\u53d1\u5e03"},sidebar:"docs",previous:{title:"\u53d1\u5e03",permalink:"/thingsgateway-docs/docs/release"},next:{title:"\u53d1\u5e03",permalink:"/thingsgateway-docs/docs/linuxrelease"}},i={},p=[{value:"\u4e00\u3001PM2\u5b88\u62a4",id:"\u4e00pm2\u5b88\u62a4",level:2},{value:"\u4e8c\u3001windows\u670d\u52a1",id:"\u4e8cwindows\u670d\u52a1",level:2},{value:"\uff08\u4e09\uff09IIS",id:"\u4e09iis",level:2}],c={toc:p};function u(e){let{components:t,...n}=e;return(0,a.kt)("wrapper",(0,r.Z)({},c,n,{components:t,mdxType:"MDXLayout"}),(0,a.kt)("h2",{id:"\u4e00pm2\u5b88\u62a4"},"\u4e00\u3001PM2\u5b88\u62a4"),(0,a.kt)("p",null,"\u8be6\u7ec6\u5b89\u88c5\u8bf7\u81ea\u884c\u67e5\u627e\u8d44\u6599"),(0,a.kt)("p",null,"\u67e5\u9605\u8be6\u7ec6\u5b98\u65b9\u6587\u6863 ",(0,a.kt)("a",{parentName:"p",href:"https://pm2.keymetrics.io/docs/usage/quick-start/"},"https://pm2.keymetrics.io/docs/usage/quick-start/")),(0,a.kt)("p",null,"\u4e0b\u9762\u4ecb\u7ecd\u4e00\u4e0b\u5e38\u7528\u6307\u4ee4"),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u5b89\u88c5pm2")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"npm install pm2@latest -g\n")),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u542f\u7528\u5e94\u7528\u7a0b\u5e8f")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"pm2 start pm2-windows.json\n")),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u505c\u6b62\u5e94\u7528\u7a0b\u5e8f")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"pm2 stop pm2-windows.json\n")),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u5f00\u673a\u81ea\u52a8\u542f\u52a8")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"npm install pm2-windows-startup -g //\u670d\u52a1\u5b89\u88c5\npm2-startup install\npm2 save //\u6bcf\u6b21\u64cd\u4f5cpm2\u5e94\u7528\u5217\u8868\u65f6\u9700\u6267\u884c\n")),(0,a.kt)("h2",{id:"\u4e8cwindows\u670d\u52a1"},"\u4e8c\u3001windows\u670d\u52a1"),(0,a.kt)("p",null,"\u9075\u5faawindows service\u670d\u52a1\u5b89\u88c5/\u542f\u52a8/\u505c\u6b62\u65b9\u5f0f ",(0,a.kt)("a",{parentName:"p",href:"https://docs.microsoft.com/zh-cn/windows-server/administration/windows-commands/sc-create"},"https://docs.microsoft.com/zh-cn/windows-server/administration/windows-commands/sc-create")," "),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u5b89\u88c5")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"sc create <Name> binPath= <Path> start= auto\nnet start <Name>\n")),(0,a.kt)("ul",null,(0,a.kt)("li",{parentName:"ul"},"\u5378\u8f7d")),(0,a.kt)("pre",null,(0,a.kt)("code",{parentName:"pre"},"net stop <Name>\nsc delete <Name>\n")),(0,a.kt)("h2",{id:"\u4e09iis"},"\uff08\u4e09\uff09IIS"),(0,a.kt)("p",null,"\u81ea\u884c\u67e5\u8be2\u76f8\u5173\u8d44\u6599 ",(0,a.kt)("strong",{parentName:"p"},"AspNetCore/IIS")))}u.isMDXComponent=!0}}]);