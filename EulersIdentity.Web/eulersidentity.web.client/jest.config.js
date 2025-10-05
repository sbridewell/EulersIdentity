export default {
    testEnvironment: 'jsdom',
    setupFilesAfterEnv: ['<rootDir>/src/setupTests.js'],
    moduleNameMapper: {
        '\\.(css|scss)$': 'identity-obj-proxy',
    },
    collectCoverage: true,
    collectCoverageFrom: ["src/**/*.{js,jsx}"],
    transform: {
        '^.+\\.[jt]sx?$': 'babel-jest',
    },
};