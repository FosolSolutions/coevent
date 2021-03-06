/* eslint-disable @typescript-eslint/no-var-requires */
/* eslint-disable @typescript-eslint/no-unused-vars */
const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
  app.use(
    '/api',
    createProxyMiddleware({
      target: process.env.API_URL || 'http://api:80/',
      changeOrigin: true,
      secure: false,
      // timeout: 2000,
      xfwd: true,
      logLevel: 'debug',
      cookiePathRewrite: '/',
      cookieDomainRewrite: '',
      pathRewrite: function (path, req) {
        return path;
      },
      onProxyReq: function (proxyReq, req, res) {
        proxyReq.setHeader('x-powered-by', 'onProxyReq');
      },
    }),
  );
};
