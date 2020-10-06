const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");

module.exports = {
	resolve: {
		modules: ["node_modules", path.resolve(__dirname + "/src")],
		alias: {
			src: path.resolve(__dirname + "/src"),
		},
	},
	entry: "./src/index.jsx",
	output: {
		path: path.join(__dirname, "/dist"),
		filename: "bundle.js",
	},
	devServer: {
		contentBase: "./dist",
		proxy: {
			"/api": {
				target: "http://localhost:80/",
			},
		},
	},
	module: {
		rules: [
			{
				test: /\.js$|jsx|.css/,
				exclude: /node_modules/,
				loader: "babel-loader",
			},
			{
				test: /\.css$/,
				use: ["style-loader", "css-loader"],
			},
		],
	},
	plugins: [new HtmlWebpackPlugin({ template: "./src/index.html" })],
};
