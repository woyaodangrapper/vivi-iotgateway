"use strict";(self.webpackChunkthingsgateway=self.webpackChunkthingsgateway||[]).push([[9223],{3905:(t,e,n)=>{n.d(e,{Zo:()=>m,kt:()=>u});var a=n(7294);function r(t,e,n){return e in t?Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}):t[e]=n,t}function i(t,e){var n=Object.keys(t);if(Object.getOwnPropertySymbols){var a=Object.getOwnPropertySymbols(t);e&&(a=a.filter((function(e){return Object.getOwnPropertyDescriptor(t,e).enumerable}))),n.push.apply(n,a)}return n}function l(t){for(var e=1;e<arguments.length;e++){var n=null!=arguments[e]?arguments[e]:{};e%2?i(Object(n),!0).forEach((function(e){r(t,e,n[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(n)):i(Object(n)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(n,e))}))}return t}function o(t,e){if(null==t)return{};var n,a,r=function(t,e){if(null==t)return{};var n,a,r={},i=Object.keys(t);for(a=0;a<i.length;a++)n=i[a],e.indexOf(n)>=0||(r[n]=t[n]);return r}(t,e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(t);for(a=0;a<i.length;a++)n=i[a],e.indexOf(n)>=0||Object.prototype.propertyIsEnumerable.call(t,n)&&(r[n]=t[n])}return r}var d=a.createContext({}),p=function(t){var e=a.useContext(d),n=e;return t&&(n="function"==typeof t?t(e):l(l({},e),t)),n},m=function(t){var e=p(t.components);return a.createElement(d.Provider,{value:e},t.children)},c={inlineCode:"code",wrapper:function(t){var e=t.children;return a.createElement(a.Fragment,{},e)}},s=a.forwardRef((function(t,e){var n=t.components,r=t.mdxType,i=t.originalType,d=t.parentName,m=o(t,["components","mdxType","originalType","parentName"]),s=p(n),u=r,k=s["".concat(d,".").concat(u)]||s[u]||c[u]||i;return n?a.createElement(k,l(l({ref:e},m),{},{components:n})):a.createElement(k,l({ref:e},m))}));function u(t,e){var n=arguments,r=e&&e.mdxType;if("string"==typeof t||r){var i=n.length,l=new Array(i);l[0]=s;var o={};for(var d in e)hasOwnProperty.call(e,d)&&(o[d]=e[d]);o.originalType=t,o.mdxType="string"==typeof t?t:r,l[1]=o;for(var p=2;p<i;p++)l[p]=n[p];return a.createElement.apply(null,l)}return a.createElement.apply(null,n)}s.displayName="MDXCreateElement"},8661:(t,e,n)=>{n.r(e),n.d(e,{assets:()=>d,contentTitle:()=>l,default:()=>c,frontMatter:()=>i,metadata:()=>o,toc:()=>p});var a=n(7462),r=(n(7294),n(3905));const i={id:"memoryvariable",title:"\u4e2d\u95f4\u53d8\u91cf"},l=void 0,o={unversionedId:"memoryvariable",id:"memoryvariable",title:"\u4e2d\u95f4\u53d8\u91cf",description:"\u66f4\u6539\u91c7\u96c6\u8bbe\u5907/\u53d8\u91cf/\u4e0a\u4f20\u8bbe\u5907/\u63d2\u4ef6\u7b49\uff0c\u9700\u8981\u91cd\u542f\u7ebf\u7a0b\uff08\u7f51\u5173\u72b6\u6001-\u8fd0\u884c\u72b6\u6001-\u5168\u90e8\u91cd\u542f/\u5355\u4e2a\u8bbe\u5907\u91cd\u542f\uff09",source:"@site/docs/memoryvariable.mdx",sourceDirName:".",slug:"/memoryvariable",permalink:"/thingsgateway-docs/docs/memoryvariable",draft:!1,editUrl:"https://gitee.com/diego2098/ThingsGateway/tree/master/handbook/docs/memoryvariable.mdx",tags:[],version:"current",lastUpdatedBy:"2248356998 qq.com",lastUpdatedAt:1689499706,formattedLastUpdatedAt:"Jul 16, 2023",frontMatter:{id:"memoryvariable",title:"\u4e2d\u95f4\u53d8\u91cf"},sidebar:"docs",previous:{title:"\u53d8\u91cf\u7ba1\u7406",permalink:"/thingsgateway-docs/docs/devicevariable"},next:{title:"\u5176\u4ed6\u914d\u7f6e",permalink:"/thingsgateway-docs/docs/otherconfig"}},d={},p=[{value:"\u4e00\u3001\u6dfb\u52a0/\u4fee\u6539\u53d8\u91cf",id:"\u4e00\u6dfb\u52a0\u4fee\u6539\u53d8\u91cf",level:2},{value:"1\u3001\u53d8\u91cf\u57fa\u672c\u5c5e\u6027",id:"1\u53d8\u91cf\u57fa\u672c\u5c5e\u6027",level:3},{value:"2\u3001\u53d8\u91cf\u62a5\u8b66\u5c5e\u6027",id:"2\u53d8\u91cf\u62a5\u8b66\u5c5e\u6027",level:3},{value:"3\u3001\u53d8\u91cf\u5386\u53f2\u5c5e\u6027",id:"3\u53d8\u91cf\u5386\u53f2\u5c5e\u6027",level:3},{value:"\u4e8c\u3001\u5bfc\u5165\u5bfc\u51fa\u53d8\u91cf",id:"\u4e8c\u5bfc\u5165\u5bfc\u51fa\u53d8\u91cf",level:2}],m={toc:p};function c(t){let{components:e,...i}=t;return(0,r.kt)("wrapper",(0,a.Z)({},m,i,{components:e,mdxType:"MDXLayout"}),(0,r.kt)("admonition",{type:"tip"},(0,r.kt)("mdxAdmonitionTitle",{parentName:"admonition"},(0,r.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"\u914d\u7f6e\u987b\u77e5")),(0,r.kt)("p",{parentName:"admonition"}," \u66f4\u6539\u91c7\u96c6\u8bbe\u5907/\u53d8\u91cf/\u4e0a\u4f20\u8bbe\u5907/\u63d2\u4ef6\u7b49\uff0c\u9700\u8981\u91cd\u542f\u7ebf\u7a0b\uff08\u7f51\u5173\u72b6\u6001-\u8fd0\u884c\u72b6\u6001-\u5168\u90e8\u91cd\u542f/\u5355\u4e2a\u8bbe\u5907\u91cd\u542f\uff09")),(0,r.kt)("admonition",{type:"tip"},(0,r.kt)("mdxAdmonitionTitle",{parentName:"admonition"},(0,r.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"\u8bf4\u660e")),(0,r.kt)("p",{parentName:"admonition"},"ThingsGateway\u91cc\u7684\u4e2d\u95f4\u53d8\u91cf\u662f\u7528\u4e8e\u4e2d\u95f4\u8ba1\u7b97\uff0c\u4e0d\u4e0e\u4eea\u8868\u4ea7\u751f\u76f4\u63a5\u8054\u7cfb")),(0,r.kt)("h2",{id:"\u4e00\u6dfb\u52a0\u4fee\u6539\u53d8\u91cf"},"\u4e00\u3001\u6dfb\u52a0/\u4fee\u6539\u53d8\u91cf"),(0,r.kt)("h3",{id:"1\u53d8\u91cf\u57fa\u672c\u5c5e\u6027"},"1\u3001\u53d8\u91cf\u57fa\u672c\u5c5e\u6027"),(0,r.kt)("p",null,(0,r.kt)("img",{src:n(4975).Z,width:"2560",height:"1550"})),(0,r.kt)("admonition",{type:"tip"},(0,r.kt)("mdxAdmonitionTitle",{parentName:"admonition"},(0,r.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"\u8bf4\u660e")),(0,r.kt)("p",{parentName:"admonition"},"\u57fa\u672c\u5c5e\u6027\u4e2d\u5b9a\u4e49\u91c7\u96c6\u5bf9\u5e94\u534f\u8bae\u6240\u9700\u7684\u914d\u7f6e")),(0,r.kt)("table",null,(0,r.kt)("thead",{parentName:"table"},(0,r.kt)("tr",{parentName:"thead"},(0,r.kt)("th",{parentName:"tr",align:null},"\u5c5e\u6027\u540d\u79f0"),(0,r.kt)("th",{parentName:"tr",align:null},"\u5c5e\u6027\u63cf\u8ff0"),(0,r.kt)("th",{parentName:"tr",align:null},"\u5907\u6ce8"))),(0,r.kt)("tbody",{parentName:"table"},(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u540d\u79f0"),(0,r.kt)("td",{parentName:"tr",align:null},"\u5f53\u524d\u53d8\u91cf\u540d\u79f0\uff0c\u5168\u5c40\u552f\u4e00(\u53d8\u91cf)"),(0,r.kt)("td",{parentName:"tr",align:null})),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u63cf\u8ff0"),(0,r.kt)("td",{parentName:"tr",align:null},"\u5f53\u524d\u53d8\u91cf\u63cf\u8ff0"),(0,r.kt)("td",{parentName:"tr",align:null})),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u8bfb\u5199\u6743\u9650"),(0,r.kt)("td",{parentName:"tr",align:null},"\u8bfb\u5199/\u53ea\u5199/\u53ea\u8bfb"),(0,r.kt)("td",{parentName:"tr",align:null})),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u8bfb\u53d6\u8868\u8fbe\u5f0f"),(0,r.kt)("td",{parentName:"tr",align:null},"\u52a8\u6001\u89e3\u6790\u7684\u8868\u8fbe\u5f0f"),(0,r.kt)("td",{parentName:"tr",align:null},"\u5177\u4f53\u53ef\u67e5\u770b ",(0,r.kt)("a",{parentName:"td",href:"https://github.com/codingseb/ExpressionEvaluator"},"ExpressionEvaluator WiKi"))),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u5199\u5165\u8868\u8fbe\u5f0f"),(0,r.kt)("td",{parentName:"tr",align:null},"\u52a8\u6001\u89e3\u6790\u7684\u8868\u8fbe\u5f0f\uff0c\u5728\u5199\u5165\u503c\u65f6\u8f6c\u5316"),(0,r.kt)("td",{parentName:"tr",align:null},"\u5177\u4f53\u53ef\u67e5\u770b ",(0,r.kt)("a",{parentName:"td",href:"https://github.com/codingseb/ExpressionEvaluator"},"ExpressionEvaluator WiKi"))),(0,r.kt)("tr",{parentName:"tbody"},(0,r.kt)("td",{parentName:"tr",align:null},"\u5141\u8bb8\u8fdc\u7a0b\u5199\u5165"),(0,r.kt)("td",{parentName:"tr",align:null},"\u5bf9\u4e8e\u53d8\u91cf\u7684\u5355\u72ec\u5199\u5165\u4f7f\u80fd\u914d\u7f6e"),(0,r.kt)("td",{parentName:"tr",align:null})))),(0,r.kt)("admonition",{type:"tip"},(0,r.kt)("mdxAdmonitionTitle",{parentName:"admonition"},(0,r.kt)("inlineCode",{parentName:"mdxAdmonitionTitle"},"\u8868\u8fbe\u5f0f\u7279\u522b\u8bf4\u660e")),(0,r.kt)("p",{parentName:"admonition"},"\u7f51\u5173\u8fd8\u652f\u6301\u8868\u8fbe\u5f0f\u7684\u52a8\u6001\u4f20\u5165,\u9664\u4e86raw\u8868\u793a\u8be5\u53d8\u91cf\u8bfb\u53d6\u7684\u539f\u59cb\u503c\u5916,\u8fd8\u652f\u6301\u5176\u4ed6\u53d8\u91cf\u7684\u503c\u4f20\u5165\u8868\u8fbe\u5f0f\n\u4e3e\u4f8b\uff1a"),(0,r.kt)("pre",{parentName:"admonition"},(0,r.kt)("code",{parentName:"pre",className:"language-csharp"},"\n//\u65b0\u5efatestInt1\u4e2d\u95f4\u53d8\u91cf\n//\u65b0\u5efatestInt2\u8bbe\u5907\u53d8\u91cf\n\n//\u5728testInt1\u7684\u8bfb\u53d6\u8868\u8fbe\u5f0f\u4e2d\u5b9a\u4e49\n\n  testInt2+3\n  \n//testInt2\u8bfb\u53d6\u503c\u4e3a8,\u8f93\u51fatestInt1=11\n\n"))),(0,r.kt)("h3",{id:"2\u53d8\u91cf\u62a5\u8b66\u5c5e\u6027"},"2\u3001\u53d8\u91cf\u62a5\u8b66\u5c5e\u6027"),(0,r.kt)("p",null," \u79fb\u81f3 ",(0,r.kt)("a",{parentName:"p",href:"/thingsgateway-docs/docs/devicevariable#2%E5%8F%98%E9%87%8F%E6%8A%A5%E8%AD%A6%E5%B1%9E%E6%80%A7"},"\u53d8\u91cf\u7ba1\u7406")," \u67e5\u770b"),(0,r.kt)("h3",{id:"3\u53d8\u91cf\u5386\u53f2\u5c5e\u6027"},"3\u3001\u53d8\u91cf\u5386\u53f2\u5c5e\u6027"),(0,r.kt)("p",null," \u79fb\u81f3 ",(0,r.kt)("a",{parentName:"p",href:"/thingsgateway-docs/docs/devicevariable#3%E5%8F%98%E9%87%8F%E5%8E%86%E5%8F%B2%E5%B1%9E%E6%80%A7"},"\u53d8\u91cf\u7ba1\u7406")," \u67e5\u770b"),(0,r.kt)("h2",{id:"\u4e8c\u5bfc\u5165\u5bfc\u51fa\u53d8\u91cf"},"\u4e8c\u3001\u5bfc\u5165\u5bfc\u51fa\u53d8\u91cf"),(0,r.kt)("p",null," \u79fb\u81f3 ",(0,r.kt)("a",{parentName:"p",href:"/thingsgateway-docs/docs/collectdevice#%E4%BA%8C%E5%AF%BC%E5%85%A5%E5%AF%BC%E5%87%BA%E9%87%87%E9%9B%86%E8%AE%BE%E5%A4%87"},"\u91c7\u96c6\u8bbe\u5907")," \u67e5\u770b"))}c.isMDXComponent=!0},4975:(t,e,n)=>{n.d(e,{Z:()=>a});const a=n.p+"assets/images/devicevariable-1-f45dfaee7c6d34f6d6f4f90eb9c8d175.png"}}]);