
// load contributors from github API
$(document).ready(() => {
	$(".js-contributor-list").each(async (index, element) => {
		let coreContributors = await $.get("https://api.github.com/repos/mta-slipe/Slipe-Core/contributors");
		let cliContributors = await $.get("https://api.github.com/repos/mta-slipe/Slipe-CLI/contributors");
	
		let contributors = [];
		let contributorLookup = {};
		for (let contributor of coreContributors){
			if (contributorLookup[contributor.id] == null) {
				contributors.push(contributor);
				contributorLookup[contributor.id] = true;
			}
		}
		for (let contributor of cliContributors){
			if (contributorLookup[contributor.id] == null) {
				contributors.push(contributor);
				contributorLookup[contributor.id] = true;
			}
		}
	
		let contributorList = $(element);
		for (let contributor of contributors) {
			if (contributor.login != "NanoBob" && contributor.login != "DezZolation") {
				let elementString = "<li><a href=\"" + contributor.html_url + "\" target=\"_blank\">" + contributor.login + "</a></li>";
				contributorList.append($(elementString));
			}
		}
	});

	// This is necesary since the sidebar toc is  asynchronously loaded after document ready
	setTimeout(() => {
		$('.sidetoc .nav a[title*=".On"]').hide();
	}, 1000);

	for (let element of document.querySelectorAll(".js-platform-link")) {
		let newHref = element.getAttribute("data-href-" + navigator.platform.toLowerCase())
		if (newHref) {
			element.setAttribute("href", newHref);
		}
	}

	$(".js-download-button").on("click", (event, element) => {
		$(".download-modal-container").toggle()
	})
	$(".download-modal-container").on("click", (event, element) => {
		$(".download-modal-container").toggle()
	})
	$(".download-modal").on("click", (event, element) => {
		event.stopPropagation();
	})

	$(".js-prod-link").each((index, link) => {
		if (document.location.href.indexOf("development.") > 0) {
			link.href = link.href.replace("-production", "-development");
		}
	});
});
