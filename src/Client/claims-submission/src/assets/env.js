(function (window) {
	window['env'] = window['env'] || {};

	let appVersion = '{appVersion}';

	if (appVersion.includes('appVersion')) {
		appVersion = '0.0.0-dev';
	}
	window['env']['appVersion'] = appVersion;
})(this);
