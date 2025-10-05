import { fileURLToPath, URL } from 'node:url';
import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';
import { env } from 'process';

// Debug code
console.log('Starting Vite development server with the following environment variables:');
console.log(env);

const baseFolder =
    env.APPDATA !== undefined && env.APPDATA !== ''
        ? `${env.APPDATA}/ASP.NET/https`
        : `${env.HOME}/.aspnet/https`;

//const certificateName = "eulersidentity.web.client";
const certificateName = "localhost";
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// Debug code
console.log(`Certificate path: ${certFilePath}`);
console.log(`Key path: ${keyFilePath}`);

if (!fs.existsSync(baseFolder)) {
    fs.mkdirSync(baseFolder, { recursive: true });
}

//if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
//    if (0 !== child_process.spawnSync('dotnet', [
//        'dev-certs',
//        'https',
//        '--export-path',
//        certFilePath,
//        '--format',
//        'Pem',
//        '--no-password',
//    ], { stdio: 'inherit', }).status) {
//        throw new Error("Could not create certificate.");
//    }
//}

//const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
//    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7050';
const target = "http://localhost:5098";

console.log(`[Proxy Target] Backend target URL: ${target}`);

//let httpsConfig;
//try {
//    httpsConfig = {
//        key: fs.readFileSync(keyFilePath),
//        cert: fs.readFileSync(certFilePath),
//    };
//    console.log(`[HTTPS] Successfully loaded certificates from ${certFilePath} and ${keyFilePath}`);
//} catch (err) {
//    console.error(`[HTTPS Error] Failed to load certificates: ${err.message}`);
//    httpsConfig = false; // Disable HTTPS if certificates cannot be loaded
//}

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '^/api': {
                target,
                secure: false,
                onError(err, req, res) {
                    console.error(`[Proxy Error] Failed to proxy request to backend: ${err.message}`);
                },
                onProxyReq(proxyReq, req, res) {
                    console.log(`[Proxy Request] ${req.method} ${req.url} -> ${target}`);
                },
                onProxyRes(proxyRes, req, res) {
                    console.log(`[Proxy Response] ${req.method} ${req.url} <- ${proxyRes.statusCode}`);
                }
            }
        },
        port: parseInt(env.DEV_SERVER_PORT || '52943'),
        https: false
    }
})
