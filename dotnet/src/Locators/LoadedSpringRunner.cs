
using System;
using Dummies;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory.Xml;
using Spring.Core.IO;
using System.IO;
using Spring.Objects.Factory;
using System.Text;

namespace Locators
{
	public class LoadedSpringRunner : ILocatorMulti
	{
		IObjectFactory k;

		const string CONFIG_SINGLETON = @"
<objects xmlns=""http://www.springframework.net"">
<object name=""IDummy0_0"" type=""Dummies.SimpleDummy0"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy0_1"" type=""Dummies.SimpleDummy1"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy0_2"" type=""Dummies.SimpleDummy2"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy1_0"" type=""Dummies.SimpleDummy3"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy1_1"" type=""Dummies.SimpleDummy4"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy1_2"" type=""Dummies.SimpleDummy5"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy2_0"" type=""Dummies.SimpleDummy6"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy2_1"" type=""Dummies.SimpleDummy7"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy2_2"" type=""Dummies.SimpleDummy8"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy3_0"" type=""Dummies.SimpleDummy9"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy3_1"" type=""Dummies.SimpleDummy10"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy3_2"" type=""Dummies.SimpleDummy11"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy4_0"" type=""Dummies.SimpleDummy12"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy4_1"" type=""Dummies.SimpleDummy13"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy4_2"" type=""Dummies.SimpleDummy14"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy5_0"" type=""Dummies.SimpleDummy15"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy5_1"" type=""Dummies.SimpleDummy16"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy5_2"" type=""Dummies.SimpleDummy17"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy6_0"" type=""Dummies.SimpleDummy18"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy6_1"" type=""Dummies.SimpleDummy19"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy6_2"" type=""Dummies.SimpleDummy20"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy7_0"" type=""Dummies.SimpleDummy21"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy7_1"" type=""Dummies.SimpleDummy22"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy7_2"" type=""Dummies.SimpleDummy23"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy8_0"" type=""Dummies.SimpleDummy24"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy8_1"" type=""Dummies.SimpleDummy25"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy8_2"" type=""Dummies.SimpleDummy26"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy9_0"" type=""Dummies.SimpleDummy27"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy9_1"" type=""Dummies.SimpleDummy28"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy9_2"" type=""Dummies.SimpleDummy29"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy10_0"" type=""Dummies.SimpleDummy30"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy10_1"" type=""Dummies.SimpleDummy31"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy10_2"" type=""Dummies.SimpleDummy32"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy11_0"" type=""Dummies.SimpleDummy33"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy11_1"" type=""Dummies.SimpleDummy34"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy11_2"" type=""Dummies.SimpleDummy35"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy12_0"" type=""Dummies.SimpleDummy36"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy12_1"" type=""Dummies.SimpleDummy37"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy12_2"" type=""Dummies.SimpleDummy38"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy13_0"" type=""Dummies.SimpleDummy39"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy13_1"" type=""Dummies.SimpleDummy40"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy13_2"" type=""Dummies.SimpleDummy41"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy14_0"" type=""Dummies.SimpleDummy42"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy14_1"" type=""Dummies.SimpleDummy43"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy14_2"" type=""Dummies.SimpleDummy44"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy15_0"" type=""Dummies.SimpleDummy45"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy15_1"" type=""Dummies.SimpleDummy46"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy15_2"" type=""Dummies.SimpleDummy47"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy16_0"" type=""Dummies.SimpleDummy48"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy16_1"" type=""Dummies.SimpleDummy49"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy16_2"" type=""Dummies.SimpleDummy50"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy17_0"" type=""Dummies.SimpleDummy51"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy17_1"" type=""Dummies.SimpleDummy52"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy17_2"" type=""Dummies.SimpleDummy53"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy18_0"" type=""Dummies.SimpleDummy54"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy18_1"" type=""Dummies.SimpleDummy55"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy18_2"" type=""Dummies.SimpleDummy56"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy19_0"" type=""Dummies.SimpleDummy57"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy19_1"" type=""Dummies.SimpleDummy58"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy19_2"" type=""Dummies.SimpleDummy59"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy20_0"" type=""Dummies.SimpleDummy60"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy20_1"" type=""Dummies.SimpleDummy61"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy20_2"" type=""Dummies.SimpleDummy62"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy21_0"" type=""Dummies.SimpleDummy63"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy21_1"" type=""Dummies.SimpleDummy64"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy21_2"" type=""Dummies.SimpleDummy65"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy22_0"" type=""Dummies.SimpleDummy66"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy22_1"" type=""Dummies.SimpleDummy67"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy22_2"" type=""Dummies.SimpleDummy68"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy23_0"" type=""Dummies.SimpleDummy69"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy23_1"" type=""Dummies.SimpleDummy70"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy23_2"" type=""Dummies.SimpleDummy71"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy24_0"" type=""Dummies.SimpleDummy72"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy24_1"" type=""Dummies.SimpleDummy73"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy24_2"" type=""Dummies.SimpleDummy74"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy25_0"" type=""Dummies.SimpleDummy75"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy25_1"" type=""Dummies.SimpleDummy76"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy25_2"" type=""Dummies.SimpleDummy77"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy26_0"" type=""Dummies.SimpleDummy78"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy26_1"" type=""Dummies.SimpleDummy79"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy26_2"" type=""Dummies.SimpleDummy80"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy27_0"" type=""Dummies.SimpleDummy81"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy27_1"" type=""Dummies.SimpleDummy82"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy27_2"" type=""Dummies.SimpleDummy83"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy28_0"" type=""Dummies.SimpleDummy84"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy28_1"" type=""Dummies.SimpleDummy85"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy28_2"" type=""Dummies.SimpleDummy86"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy29_0"" type=""Dummies.SimpleDummy87"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy29_1"" type=""Dummies.SimpleDummy88"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy29_2"" type=""Dummies.SimpleDummy89"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy30_0"" type=""Dummies.SimpleDummy90"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy30_1"" type=""Dummies.SimpleDummy91"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy30_2"" type=""Dummies.SimpleDummy92"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy31_0"" type=""Dummies.SimpleDummy93"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy31_1"" type=""Dummies.SimpleDummy94"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy31_2"" type=""Dummies.SimpleDummy95"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy32_0"" type=""Dummies.SimpleDummy96"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy32_1"" type=""Dummies.SimpleDummy97"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy32_2"" type=""Dummies.SimpleDummy98"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy33_0"" type=""Dummies.SimpleDummy99"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy33_1"" type=""Dummies.SimpleDummy100"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy33_2"" type=""Dummies.SimpleDummy101"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy34_0"" type=""Dummies.SimpleDummy102"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy34_1"" type=""Dummies.SimpleDummy103"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy34_2"" type=""Dummies.SimpleDummy104"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy35_0"" type=""Dummies.SimpleDummy105"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy35_1"" type=""Dummies.SimpleDummy106"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy35_2"" type=""Dummies.SimpleDummy107"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy36_0"" type=""Dummies.SimpleDummy108"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy36_1"" type=""Dummies.SimpleDummy109"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy36_2"" type=""Dummies.SimpleDummy110"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy37_0"" type=""Dummies.SimpleDummy111"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy37_1"" type=""Dummies.SimpleDummy112"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy37_2"" type=""Dummies.SimpleDummy113"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy38_0"" type=""Dummies.SimpleDummy114"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy38_1"" type=""Dummies.SimpleDummy115"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy38_2"" type=""Dummies.SimpleDummy116"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy39_0"" type=""Dummies.SimpleDummy117"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy39_1"" type=""Dummies.SimpleDummy118"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy39_2"" type=""Dummies.SimpleDummy119"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy40_0"" type=""Dummies.SimpleDummy120"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy40_1"" type=""Dummies.SimpleDummy121"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy40_2"" type=""Dummies.SimpleDummy122"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy41_0"" type=""Dummies.SimpleDummy123"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy41_1"" type=""Dummies.SimpleDummy124"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy41_2"" type=""Dummies.SimpleDummy125"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy42_0"" type=""Dummies.SimpleDummy126"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy42_1"" type=""Dummies.SimpleDummy127"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy42_2"" type=""Dummies.SimpleDummy128"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy43_0"" type=""Dummies.SimpleDummy129"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy43_1"" type=""Dummies.SimpleDummy130"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy43_2"" type=""Dummies.SimpleDummy131"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy44_0"" type=""Dummies.SimpleDummy132"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy44_1"" type=""Dummies.SimpleDummy133"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy44_2"" type=""Dummies.SimpleDummy134"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy45_0"" type=""Dummies.SimpleDummy135"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy45_1"" type=""Dummies.SimpleDummy136"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy45_2"" type=""Dummies.SimpleDummy137"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy46_0"" type=""Dummies.SimpleDummy138"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy46_1"" type=""Dummies.SimpleDummy139"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy46_2"" type=""Dummies.SimpleDummy140"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy47_0"" type=""Dummies.SimpleDummy141"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy47_1"" type=""Dummies.SimpleDummy142"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy47_2"" type=""Dummies.SimpleDummy143"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy48_0"" type=""Dummies.SimpleDummy144"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy48_1"" type=""Dummies.SimpleDummy145"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy48_2"" type=""Dummies.SimpleDummy146"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy49_0"" type=""Dummies.SimpleDummy147"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy49_1"" type=""Dummies.SimpleDummy148"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy49_2"" type=""Dummies.SimpleDummy149"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy50_0"" type=""Dummies.SimpleDummy150"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy50_1"" type=""Dummies.SimpleDummy151"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy50_2"" type=""Dummies.SimpleDummy152"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy51_0"" type=""Dummies.SimpleDummy153"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy51_1"" type=""Dummies.SimpleDummy154"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy51_2"" type=""Dummies.SimpleDummy155"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy52_0"" type=""Dummies.SimpleDummy156"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy52_1"" type=""Dummies.SimpleDummy157"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy52_2"" type=""Dummies.SimpleDummy158"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy53_0"" type=""Dummies.SimpleDummy159"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy53_1"" type=""Dummies.SimpleDummy160"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy53_2"" type=""Dummies.SimpleDummy161"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy54_0"" type=""Dummies.SimpleDummy162"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy54_1"" type=""Dummies.SimpleDummy163"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy54_2"" type=""Dummies.SimpleDummy164"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy55_0"" type=""Dummies.SimpleDummy165"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy55_1"" type=""Dummies.SimpleDummy166"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy55_2"" type=""Dummies.SimpleDummy167"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy56_0"" type=""Dummies.SimpleDummy168"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy56_1"" type=""Dummies.SimpleDummy169"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy56_2"" type=""Dummies.SimpleDummy170"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy57_0"" type=""Dummies.SimpleDummy171"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy57_1"" type=""Dummies.SimpleDummy172"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy57_2"" type=""Dummies.SimpleDummy173"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy58_0"" type=""Dummies.SimpleDummy174"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy58_1"" type=""Dummies.SimpleDummy175"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy58_2"" type=""Dummies.SimpleDummy176"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy59_0"" type=""Dummies.SimpleDummy177"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy59_1"" type=""Dummies.SimpleDummy178"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy59_2"" type=""Dummies.SimpleDummy179"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy60_0"" type=""Dummies.SimpleDummy180"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy60_1"" type=""Dummies.SimpleDummy181"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy60_2"" type=""Dummies.SimpleDummy182"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy61_0"" type=""Dummies.SimpleDummy183"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy61_1"" type=""Dummies.SimpleDummy184"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy61_2"" type=""Dummies.SimpleDummy185"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy62_0"" type=""Dummies.SimpleDummy186"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy62_1"" type=""Dummies.SimpleDummy187"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy62_2"" type=""Dummies.SimpleDummy188"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy63_0"" type=""Dummies.SimpleDummy189"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy63_1"" type=""Dummies.SimpleDummy190"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy63_2"" type=""Dummies.SimpleDummy191"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy64_0"" type=""Dummies.SimpleDummy192"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy64_1"" type=""Dummies.SimpleDummy193"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy64_2"" type=""Dummies.SimpleDummy194"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy65_0"" type=""Dummies.SimpleDummy195"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy65_1"" type=""Dummies.SimpleDummy196"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy65_2"" type=""Dummies.SimpleDummy197"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy66_0"" type=""Dummies.SimpleDummy198"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy66_1"" type=""Dummies.SimpleDummy199"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy66_2"" type=""Dummies.SimpleDummy200"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy67_0"" type=""Dummies.SimpleDummy201"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy67_1"" type=""Dummies.SimpleDummy202"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy67_2"" type=""Dummies.SimpleDummy203"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy68_0"" type=""Dummies.SimpleDummy204"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy68_1"" type=""Dummies.SimpleDummy205"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy68_2"" type=""Dummies.SimpleDummy206"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy69_0"" type=""Dummies.SimpleDummy207"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy69_1"" type=""Dummies.SimpleDummy208"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy69_2"" type=""Dummies.SimpleDummy209"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy70_0"" type=""Dummies.SimpleDummy210"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy70_1"" type=""Dummies.SimpleDummy211"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy70_2"" type=""Dummies.SimpleDummy212"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy71_0"" type=""Dummies.SimpleDummy213"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy71_1"" type=""Dummies.SimpleDummy214"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy71_2"" type=""Dummies.SimpleDummy215"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy72_0"" type=""Dummies.SimpleDummy216"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy72_1"" type=""Dummies.SimpleDummy217"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy72_2"" type=""Dummies.SimpleDummy218"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy73_0"" type=""Dummies.SimpleDummy219"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy73_1"" type=""Dummies.SimpleDummy220"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy73_2"" type=""Dummies.SimpleDummy221"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy74_0"" type=""Dummies.SimpleDummy222"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy74_1"" type=""Dummies.SimpleDummy223"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy74_2"" type=""Dummies.SimpleDummy224"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy75_0"" type=""Dummies.SimpleDummy225"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy75_1"" type=""Dummies.SimpleDummy226"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy75_2"" type=""Dummies.SimpleDummy227"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy76_0"" type=""Dummies.SimpleDummy228"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy76_1"" type=""Dummies.SimpleDummy229"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy76_2"" type=""Dummies.SimpleDummy230"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy77_0"" type=""Dummies.SimpleDummy231"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy77_1"" type=""Dummies.SimpleDummy232"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy77_2"" type=""Dummies.SimpleDummy233"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy78_0"" type=""Dummies.SimpleDummy234"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy78_1"" type=""Dummies.SimpleDummy235"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy78_2"" type=""Dummies.SimpleDummy236"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy79_0"" type=""Dummies.SimpleDummy237"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy79_1"" type=""Dummies.SimpleDummy238"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy79_2"" type=""Dummies.SimpleDummy239"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy80_0"" type=""Dummies.SimpleDummy240"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy80_1"" type=""Dummies.SimpleDummy241"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy80_2"" type=""Dummies.SimpleDummy242"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy81_0"" type=""Dummies.SimpleDummy243"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy81_1"" type=""Dummies.SimpleDummy244"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy81_2"" type=""Dummies.SimpleDummy245"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy82_0"" type=""Dummies.SimpleDummy246"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy82_1"" type=""Dummies.SimpleDummy247"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy82_2"" type=""Dummies.SimpleDummy248"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy83_0"" type=""Dummies.SimpleDummy249"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy83_1"" type=""Dummies.SimpleDummy250"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy83_2"" type=""Dummies.SimpleDummy251"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy84_0"" type=""Dummies.SimpleDummy252"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy84_1"" type=""Dummies.SimpleDummy253"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy84_2"" type=""Dummies.SimpleDummy254"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy85_0"" type=""Dummies.SimpleDummy255"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy85_1"" type=""Dummies.SimpleDummy256"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy85_2"" type=""Dummies.SimpleDummy257"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy86_0"" type=""Dummies.SimpleDummy258"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy86_1"" type=""Dummies.SimpleDummy259"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy86_2"" type=""Dummies.SimpleDummy260"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy87_0"" type=""Dummies.SimpleDummy261"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy87_1"" type=""Dummies.SimpleDummy262"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy87_2"" type=""Dummies.SimpleDummy263"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy88_0"" type=""Dummies.SimpleDummy264"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy88_1"" type=""Dummies.SimpleDummy265"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy88_2"" type=""Dummies.SimpleDummy266"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy89_0"" type=""Dummies.SimpleDummy267"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy89_1"" type=""Dummies.SimpleDummy268"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy89_2"" type=""Dummies.SimpleDummy269"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy90_0"" type=""Dummies.SimpleDummy270"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy90_1"" type=""Dummies.SimpleDummy271"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy90_2"" type=""Dummies.SimpleDummy272"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy91_0"" type=""Dummies.SimpleDummy273"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy91_1"" type=""Dummies.SimpleDummy274"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy91_2"" type=""Dummies.SimpleDummy275"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy92_0"" type=""Dummies.SimpleDummy276"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy92_1"" type=""Dummies.SimpleDummy277"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy92_2"" type=""Dummies.SimpleDummy278"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy93_0"" type=""Dummies.SimpleDummy279"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy93_1"" type=""Dummies.SimpleDummy280"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy93_2"" type=""Dummies.SimpleDummy281"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy94_0"" type=""Dummies.SimpleDummy282"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy94_1"" type=""Dummies.SimpleDummy283"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy94_2"" type=""Dummies.SimpleDummy284"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy95_0"" type=""Dummies.SimpleDummy285"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy95_1"" type=""Dummies.SimpleDummy286"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy95_2"" type=""Dummies.SimpleDummy287"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy96_0"" type=""Dummies.SimpleDummy288"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy96_1"" type=""Dummies.SimpleDummy289"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy96_2"" type=""Dummies.SimpleDummy290"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy97_0"" type=""Dummies.SimpleDummy291"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy97_1"" type=""Dummies.SimpleDummy292"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy97_2"" type=""Dummies.SimpleDummy293"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy98_0"" type=""Dummies.SimpleDummy294"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy98_1"" type=""Dummies.SimpleDummy295"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy98_2"" type=""Dummies.SimpleDummy296"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy99_0"" type=""Dummies.SimpleDummy297"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy99_1"" type=""Dummies.SimpleDummy298"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy99_2"" type=""Dummies.SimpleDummy299"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy100_0"" type=""Dummies.SimpleDummy300"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy100_1"" type=""Dummies.SimpleDummy301"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy100_2"" type=""Dummies.SimpleDummy302"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy101_0"" type=""Dummies.SimpleDummy303"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy101_1"" type=""Dummies.SimpleDummy304"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy101_2"" type=""Dummies.SimpleDummy305"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy102_0"" type=""Dummies.SimpleDummy306"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy102_1"" type=""Dummies.SimpleDummy307"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy102_2"" type=""Dummies.SimpleDummy308"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy103_0"" type=""Dummies.SimpleDummy309"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy103_1"" type=""Dummies.SimpleDummy310"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy103_2"" type=""Dummies.SimpleDummy311"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy104_0"" type=""Dummies.SimpleDummy312"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy104_1"" type=""Dummies.SimpleDummy313"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy104_2"" type=""Dummies.SimpleDummy314"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy105_0"" type=""Dummies.SimpleDummy315"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy105_1"" type=""Dummies.SimpleDummy316"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy105_2"" type=""Dummies.SimpleDummy317"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy106_0"" type=""Dummies.SimpleDummy318"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy106_1"" type=""Dummies.SimpleDummy319"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy106_2"" type=""Dummies.SimpleDummy320"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy107_0"" type=""Dummies.SimpleDummy321"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy107_1"" type=""Dummies.SimpleDummy322"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy107_2"" type=""Dummies.SimpleDummy323"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy108_0"" type=""Dummies.SimpleDummy324"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy108_1"" type=""Dummies.SimpleDummy325"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy108_2"" type=""Dummies.SimpleDummy326"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy109_0"" type=""Dummies.SimpleDummy327"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy109_1"" type=""Dummies.SimpleDummy328"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy109_2"" type=""Dummies.SimpleDummy329"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy110_0"" type=""Dummies.SimpleDummy330"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy110_1"" type=""Dummies.SimpleDummy331"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy110_2"" type=""Dummies.SimpleDummy332"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy111_0"" type=""Dummies.SimpleDummy333"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy111_1"" type=""Dummies.SimpleDummy334"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy111_2"" type=""Dummies.SimpleDummy335"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy112_0"" type=""Dummies.SimpleDummy336"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy112_1"" type=""Dummies.SimpleDummy337"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy112_2"" type=""Dummies.SimpleDummy338"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy113_0"" type=""Dummies.SimpleDummy339"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy113_1"" type=""Dummies.SimpleDummy340"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy113_2"" type=""Dummies.SimpleDummy341"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy114_0"" type=""Dummies.SimpleDummy342"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy114_1"" type=""Dummies.SimpleDummy343"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy114_2"" type=""Dummies.SimpleDummy344"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy115_0"" type=""Dummies.SimpleDummy345"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy115_1"" type=""Dummies.SimpleDummy346"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy115_2"" type=""Dummies.SimpleDummy347"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy116_0"" type=""Dummies.SimpleDummy348"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy116_1"" type=""Dummies.SimpleDummy349"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy116_2"" type=""Dummies.SimpleDummy350"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy117_0"" type=""Dummies.SimpleDummy351"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy117_1"" type=""Dummies.SimpleDummy352"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy117_2"" type=""Dummies.SimpleDummy353"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy118_0"" type=""Dummies.SimpleDummy354"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy118_1"" type=""Dummies.SimpleDummy355"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy118_2"" type=""Dummies.SimpleDummy356"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy119_0"" type=""Dummies.SimpleDummy357"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy119_1"" type=""Dummies.SimpleDummy358"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy119_2"" type=""Dummies.SimpleDummy359"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy120_0"" type=""Dummies.SimpleDummy360"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy120_1"" type=""Dummies.SimpleDummy361"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy120_2"" type=""Dummies.SimpleDummy362"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy121_0"" type=""Dummies.SimpleDummy363"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy121_1"" type=""Dummies.SimpleDummy364"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy121_2"" type=""Dummies.SimpleDummy365"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy122_0"" type=""Dummies.SimpleDummy366"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy122_1"" type=""Dummies.SimpleDummy367"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy122_2"" type=""Dummies.SimpleDummy368"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy123_0"" type=""Dummies.SimpleDummy369"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy123_1"" type=""Dummies.SimpleDummy370"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy123_2"" type=""Dummies.SimpleDummy371"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy124_0"" type=""Dummies.SimpleDummy372"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy124_1"" type=""Dummies.SimpleDummy373"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy124_2"" type=""Dummies.SimpleDummy374"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy125_0"" type=""Dummies.SimpleDummy375"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy125_1"" type=""Dummies.SimpleDummy376"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy125_2"" type=""Dummies.SimpleDummy377"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy126_0"" type=""Dummies.SimpleDummy378"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy126_1"" type=""Dummies.SimpleDummy379"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy126_2"" type=""Dummies.SimpleDummy380"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy127_0"" type=""Dummies.SimpleDummy381"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy127_1"" type=""Dummies.SimpleDummy382"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy127_2"" type=""Dummies.SimpleDummy383"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy128_0"" type=""Dummies.SimpleDummy384"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy128_1"" type=""Dummies.SimpleDummy385"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy128_2"" type=""Dummies.SimpleDummy386"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy129_0"" type=""Dummies.SimpleDummy387"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy129_1"" type=""Dummies.SimpleDummy388"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy129_2"" type=""Dummies.SimpleDummy389"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy130_0"" type=""Dummies.SimpleDummy390"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy130_1"" type=""Dummies.SimpleDummy391"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy130_2"" type=""Dummies.SimpleDummy392"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy131_0"" type=""Dummies.SimpleDummy393"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy131_1"" type=""Dummies.SimpleDummy394"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy131_2"" type=""Dummies.SimpleDummy395"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy132_0"" type=""Dummies.SimpleDummy396"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy132_1"" type=""Dummies.SimpleDummy397"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy132_2"" type=""Dummies.SimpleDummy398"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy133_0"" type=""Dummies.SimpleDummy399"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy133_1"" type=""Dummies.SimpleDummy400"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy133_2"" type=""Dummies.SimpleDummy401"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy134_0"" type=""Dummies.SimpleDummy402"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy134_1"" type=""Dummies.SimpleDummy403"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy134_2"" type=""Dummies.SimpleDummy404"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy135_0"" type=""Dummies.SimpleDummy405"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy135_1"" type=""Dummies.SimpleDummy406"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy135_2"" type=""Dummies.SimpleDummy407"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy136_0"" type=""Dummies.SimpleDummy408"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy136_1"" type=""Dummies.SimpleDummy409"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy136_2"" type=""Dummies.SimpleDummy410"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy137_0"" type=""Dummies.SimpleDummy411"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy137_1"" type=""Dummies.SimpleDummy412"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy137_2"" type=""Dummies.SimpleDummy413"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy138_0"" type=""Dummies.SimpleDummy414"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy138_1"" type=""Dummies.SimpleDummy415"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy138_2"" type=""Dummies.SimpleDummy416"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy139_0"" type=""Dummies.SimpleDummy417"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy139_1"" type=""Dummies.SimpleDummy418"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy139_2"" type=""Dummies.SimpleDummy419"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy140_0"" type=""Dummies.SimpleDummy420"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy140_1"" type=""Dummies.SimpleDummy421"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy140_2"" type=""Dummies.SimpleDummy422"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy141_0"" type=""Dummies.SimpleDummy423"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy141_1"" type=""Dummies.SimpleDummy424"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy141_2"" type=""Dummies.SimpleDummy425"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy142_0"" type=""Dummies.SimpleDummy426"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy142_1"" type=""Dummies.SimpleDummy427"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy142_2"" type=""Dummies.SimpleDummy428"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy143_0"" type=""Dummies.SimpleDummy429"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy143_1"" type=""Dummies.SimpleDummy430"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy143_2"" type=""Dummies.SimpleDummy431"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy144_0"" type=""Dummies.SimpleDummy432"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy144_1"" type=""Dummies.SimpleDummy433"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy144_2"" type=""Dummies.SimpleDummy434"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy145_0"" type=""Dummies.SimpleDummy435"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy145_1"" type=""Dummies.SimpleDummy436"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy145_2"" type=""Dummies.SimpleDummy437"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy146_0"" type=""Dummies.SimpleDummy438"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy146_1"" type=""Dummies.SimpleDummy439"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy146_2"" type=""Dummies.SimpleDummy440"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy147_0"" type=""Dummies.SimpleDummy441"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy147_1"" type=""Dummies.SimpleDummy442"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy147_2"" type=""Dummies.SimpleDummy443"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy148_0"" type=""Dummies.SimpleDummy444"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy148_1"" type=""Dummies.SimpleDummy445"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy148_2"" type=""Dummies.SimpleDummy446"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy149_0"" type=""Dummies.SimpleDummy447"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy149_1"" type=""Dummies.SimpleDummy448"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy149_2"" type=""Dummies.SimpleDummy449"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy150_0"" type=""Dummies.SimpleDummy450"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy150_1"" type=""Dummies.SimpleDummy451"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy150_2"" type=""Dummies.SimpleDummy452"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy151_0"" type=""Dummies.SimpleDummy453"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy151_1"" type=""Dummies.SimpleDummy454"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy151_2"" type=""Dummies.SimpleDummy455"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy152_0"" type=""Dummies.SimpleDummy456"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy152_1"" type=""Dummies.SimpleDummy457"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy152_2"" type=""Dummies.SimpleDummy458"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy153_0"" type=""Dummies.SimpleDummy459"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy153_1"" type=""Dummies.SimpleDummy460"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy153_2"" type=""Dummies.SimpleDummy461"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy154_0"" type=""Dummies.SimpleDummy462"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy154_1"" type=""Dummies.SimpleDummy463"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy154_2"" type=""Dummies.SimpleDummy464"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy155_0"" type=""Dummies.SimpleDummy465"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy155_1"" type=""Dummies.SimpleDummy466"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy155_2"" type=""Dummies.SimpleDummy467"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy156_0"" type=""Dummies.SimpleDummy468"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy156_1"" type=""Dummies.SimpleDummy469"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy156_2"" type=""Dummies.SimpleDummy470"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy157_0"" type=""Dummies.SimpleDummy471"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy157_1"" type=""Dummies.SimpleDummy472"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy157_2"" type=""Dummies.SimpleDummy473"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy158_0"" type=""Dummies.SimpleDummy474"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy158_1"" type=""Dummies.SimpleDummy475"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy158_2"" type=""Dummies.SimpleDummy476"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy159_0"" type=""Dummies.SimpleDummy477"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy159_1"" type=""Dummies.SimpleDummy478"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy159_2"" type=""Dummies.SimpleDummy479"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy160_0"" type=""Dummies.SimpleDummy480"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy160_1"" type=""Dummies.SimpleDummy481"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy160_2"" type=""Dummies.SimpleDummy482"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy161_0"" type=""Dummies.SimpleDummy483"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy161_1"" type=""Dummies.SimpleDummy484"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy161_2"" type=""Dummies.SimpleDummy485"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy162_0"" type=""Dummies.SimpleDummy486"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy162_1"" type=""Dummies.SimpleDummy487"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy162_2"" type=""Dummies.SimpleDummy488"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy163_0"" type=""Dummies.SimpleDummy489"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy163_1"" type=""Dummies.SimpleDummy490"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy163_2"" type=""Dummies.SimpleDummy491"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy164_0"" type=""Dummies.SimpleDummy492"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy164_1"" type=""Dummies.SimpleDummy493"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy164_2"" type=""Dummies.SimpleDummy494"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy165_0"" type=""Dummies.SimpleDummy495"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy165_1"" type=""Dummies.SimpleDummy496"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy165_2"" type=""Dummies.SimpleDummy497"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy166_0"" type=""Dummies.SimpleDummy498"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy166_1"" type=""Dummies.SimpleDummy499"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy166_2"" type=""Dummies.SimpleDummy500"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy167_0"" type=""Dummies.SimpleDummy501"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy167_1"" type=""Dummies.SimpleDummy502"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy167_2"" type=""Dummies.SimpleDummy503"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy168_0"" type=""Dummies.SimpleDummy504"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy168_1"" type=""Dummies.SimpleDummy505"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy168_2"" type=""Dummies.SimpleDummy506"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy169_0"" type=""Dummies.SimpleDummy507"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy169_1"" type=""Dummies.SimpleDummy508"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy169_2"" type=""Dummies.SimpleDummy509"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy170_0"" type=""Dummies.SimpleDummy510"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy170_1"" type=""Dummies.SimpleDummy511"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy170_2"" type=""Dummies.SimpleDummy512"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy171_0"" type=""Dummies.SimpleDummy513"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy171_1"" type=""Dummies.SimpleDummy514"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy171_2"" type=""Dummies.SimpleDummy515"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy172_0"" type=""Dummies.SimpleDummy516"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy172_1"" type=""Dummies.SimpleDummy517"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy172_2"" type=""Dummies.SimpleDummy518"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy173_0"" type=""Dummies.SimpleDummy519"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy173_1"" type=""Dummies.SimpleDummy520"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy173_2"" type=""Dummies.SimpleDummy521"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy174_0"" type=""Dummies.SimpleDummy522"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy174_1"" type=""Dummies.SimpleDummy523"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy174_2"" type=""Dummies.SimpleDummy524"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy175_0"" type=""Dummies.SimpleDummy525"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy175_1"" type=""Dummies.SimpleDummy526"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy175_2"" type=""Dummies.SimpleDummy527"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy176_0"" type=""Dummies.SimpleDummy528"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy176_1"" type=""Dummies.SimpleDummy529"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy176_2"" type=""Dummies.SimpleDummy530"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy177_0"" type=""Dummies.SimpleDummy531"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy177_1"" type=""Dummies.SimpleDummy532"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy177_2"" type=""Dummies.SimpleDummy533"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy178_0"" type=""Dummies.SimpleDummy534"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy178_1"" type=""Dummies.SimpleDummy535"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy178_2"" type=""Dummies.SimpleDummy536"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy179_0"" type=""Dummies.SimpleDummy537"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy179_1"" type=""Dummies.SimpleDummy538"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy179_2"" type=""Dummies.SimpleDummy539"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy180_0"" type=""Dummies.SimpleDummy540"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy180_1"" type=""Dummies.SimpleDummy541"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy180_2"" type=""Dummies.SimpleDummy542"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy181_0"" type=""Dummies.SimpleDummy543"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy181_1"" type=""Dummies.SimpleDummy544"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy181_2"" type=""Dummies.SimpleDummy545"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy182_0"" type=""Dummies.SimpleDummy546"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy182_1"" type=""Dummies.SimpleDummy547"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy182_2"" type=""Dummies.SimpleDummy548"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy183_0"" type=""Dummies.SimpleDummy549"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy183_1"" type=""Dummies.SimpleDummy550"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy183_2"" type=""Dummies.SimpleDummy551"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy184_0"" type=""Dummies.SimpleDummy552"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy184_1"" type=""Dummies.SimpleDummy553"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy184_2"" type=""Dummies.SimpleDummy554"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy185_0"" type=""Dummies.SimpleDummy555"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy185_1"" type=""Dummies.SimpleDummy556"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy185_2"" type=""Dummies.SimpleDummy557"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy186_0"" type=""Dummies.SimpleDummy558"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy186_1"" type=""Dummies.SimpleDummy559"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy186_2"" type=""Dummies.SimpleDummy560"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy187_0"" type=""Dummies.SimpleDummy561"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy187_1"" type=""Dummies.SimpleDummy562"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy187_2"" type=""Dummies.SimpleDummy563"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy188_0"" type=""Dummies.SimpleDummy564"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy188_1"" type=""Dummies.SimpleDummy565"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy188_2"" type=""Dummies.SimpleDummy566"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy189_0"" type=""Dummies.SimpleDummy567"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy189_1"" type=""Dummies.SimpleDummy568"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy189_2"" type=""Dummies.SimpleDummy569"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy190_0"" type=""Dummies.SimpleDummy570"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy190_1"" type=""Dummies.SimpleDummy571"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy190_2"" type=""Dummies.SimpleDummy572"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy191_0"" type=""Dummies.SimpleDummy573"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy191_1"" type=""Dummies.SimpleDummy574"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy191_2"" type=""Dummies.SimpleDummy575"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy192_0"" type=""Dummies.SimpleDummy576"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy192_1"" type=""Dummies.SimpleDummy577"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy192_2"" type=""Dummies.SimpleDummy578"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy193_0"" type=""Dummies.SimpleDummy579"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy193_1"" type=""Dummies.SimpleDummy580"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy193_2"" type=""Dummies.SimpleDummy581"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy194_0"" type=""Dummies.SimpleDummy582"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy194_1"" type=""Dummies.SimpleDummy583"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy194_2"" type=""Dummies.SimpleDummy584"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy195_0"" type=""Dummies.SimpleDummy585"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy195_1"" type=""Dummies.SimpleDummy586"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy195_2"" type=""Dummies.SimpleDummy587"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy196_0"" type=""Dummies.SimpleDummy588"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy196_1"" type=""Dummies.SimpleDummy589"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy196_2"" type=""Dummies.SimpleDummy590"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy197_0"" type=""Dummies.SimpleDummy591"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy197_1"" type=""Dummies.SimpleDummy592"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy197_2"" type=""Dummies.SimpleDummy593"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy198_0"" type=""Dummies.SimpleDummy594"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy198_1"" type=""Dummies.SimpleDummy595"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy198_2"" type=""Dummies.SimpleDummy596"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy199_0"" type=""Dummies.SimpleDummy597"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy199_1"" type=""Dummies.SimpleDummy598"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy199_2"" type=""Dummies.SimpleDummy599"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy200_0"" type=""Dummies.SimpleDummy600"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy200_1"" type=""Dummies.SimpleDummy601"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy200_2"" type=""Dummies.SimpleDummy602"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy201_0"" type=""Dummies.SimpleDummy603"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy201_1"" type=""Dummies.SimpleDummy604"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy201_2"" type=""Dummies.SimpleDummy605"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy202_0"" type=""Dummies.SimpleDummy606"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy202_1"" type=""Dummies.SimpleDummy607"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy202_2"" type=""Dummies.SimpleDummy608"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy203_0"" type=""Dummies.SimpleDummy609"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy203_1"" type=""Dummies.SimpleDummy610"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy203_2"" type=""Dummies.SimpleDummy611"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy204_0"" type=""Dummies.SimpleDummy612"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy204_1"" type=""Dummies.SimpleDummy613"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy204_2"" type=""Dummies.SimpleDummy614"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy205_0"" type=""Dummies.SimpleDummy615"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy205_1"" type=""Dummies.SimpleDummy616"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy205_2"" type=""Dummies.SimpleDummy617"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy206_0"" type=""Dummies.SimpleDummy618"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy206_1"" type=""Dummies.SimpleDummy619"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy206_2"" type=""Dummies.SimpleDummy620"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy207_0"" type=""Dummies.SimpleDummy621"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy207_1"" type=""Dummies.SimpleDummy622"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy207_2"" type=""Dummies.SimpleDummy623"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy208_0"" type=""Dummies.SimpleDummy624"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy208_1"" type=""Dummies.SimpleDummy625"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy208_2"" type=""Dummies.SimpleDummy626"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy209_0"" type=""Dummies.SimpleDummy627"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy209_1"" type=""Dummies.SimpleDummy628"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy209_2"" type=""Dummies.SimpleDummy629"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy210_0"" type=""Dummies.SimpleDummy630"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy210_1"" type=""Dummies.SimpleDummy631"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy210_2"" type=""Dummies.SimpleDummy632"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy211_0"" type=""Dummies.SimpleDummy633"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy211_1"" type=""Dummies.SimpleDummy634"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy211_2"" type=""Dummies.SimpleDummy635"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy212_0"" type=""Dummies.SimpleDummy636"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy212_1"" type=""Dummies.SimpleDummy637"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy212_2"" type=""Dummies.SimpleDummy638"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy213_0"" type=""Dummies.SimpleDummy639"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy213_1"" type=""Dummies.SimpleDummy640"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy213_2"" type=""Dummies.SimpleDummy641"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy214_0"" type=""Dummies.SimpleDummy642"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy214_1"" type=""Dummies.SimpleDummy643"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy214_2"" type=""Dummies.SimpleDummy644"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy215_0"" type=""Dummies.SimpleDummy645"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy215_1"" type=""Dummies.SimpleDummy646"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy215_2"" type=""Dummies.SimpleDummy647"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy216_0"" type=""Dummies.SimpleDummy648"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy216_1"" type=""Dummies.SimpleDummy649"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy216_2"" type=""Dummies.SimpleDummy650"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy217_0"" type=""Dummies.SimpleDummy651"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy217_1"" type=""Dummies.SimpleDummy652"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy217_2"" type=""Dummies.SimpleDummy653"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy218_0"" type=""Dummies.SimpleDummy654"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy218_1"" type=""Dummies.SimpleDummy655"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy218_2"" type=""Dummies.SimpleDummy656"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy219_0"" type=""Dummies.SimpleDummy657"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy219_1"" type=""Dummies.SimpleDummy658"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy219_2"" type=""Dummies.SimpleDummy659"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy220_0"" type=""Dummies.SimpleDummy660"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy220_1"" type=""Dummies.SimpleDummy661"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy220_2"" type=""Dummies.SimpleDummy662"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy221_0"" type=""Dummies.SimpleDummy663"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy221_1"" type=""Dummies.SimpleDummy664"" singleton=""true"" lazy-init=""true"" />
<object name=""IDummy221_2"" type=""Dummies.SimpleDummy665"" singleton=""true"" lazy-init=""true"" />

</objects>";


		const string CONFIG_TRANSIENT = @"
<objects xmlns=""http://www.springframework.net"">
<object name=""IDummy0_0"" type=""Dummies.SimpleDummy0"" singleton=""false"" />
<object name=""IDummy0_1"" type=""Dummies.SimpleDummy1"" singleton=""false"" />
<object name=""IDummy0_2"" type=""Dummies.SimpleDummy2"" singleton=""false"" />
<object name=""IDummy1_0"" type=""Dummies.SimpleDummy3"" singleton=""false"" />
<object name=""IDummy1_1"" type=""Dummies.SimpleDummy4"" singleton=""false"" />
<object name=""IDummy1_2"" type=""Dummies.SimpleDummy5"" singleton=""false"" />
<object name=""IDummy2_0"" type=""Dummies.SimpleDummy6"" singleton=""false"" />
<object name=""IDummy2_1"" type=""Dummies.SimpleDummy7"" singleton=""false"" />
<object name=""IDummy2_2"" type=""Dummies.SimpleDummy8"" singleton=""false"" />
<object name=""IDummy3_0"" type=""Dummies.SimpleDummy9"" singleton=""false"" />
<object name=""IDummy3_1"" type=""Dummies.SimpleDummy10"" singleton=""false"" />
<object name=""IDummy3_2"" type=""Dummies.SimpleDummy11"" singleton=""false"" />
<object name=""IDummy4_0"" type=""Dummies.SimpleDummy12"" singleton=""false"" />
<object name=""IDummy4_1"" type=""Dummies.SimpleDummy13"" singleton=""false"" />
<object name=""IDummy4_2"" type=""Dummies.SimpleDummy14"" singleton=""false"" />
<object name=""IDummy5_0"" type=""Dummies.SimpleDummy15"" singleton=""false"" />
<object name=""IDummy5_1"" type=""Dummies.SimpleDummy16"" singleton=""false"" />
<object name=""IDummy5_2"" type=""Dummies.SimpleDummy17"" singleton=""false"" />
<object name=""IDummy6_0"" type=""Dummies.SimpleDummy18"" singleton=""false"" />
<object name=""IDummy6_1"" type=""Dummies.SimpleDummy19"" singleton=""false"" />
<object name=""IDummy6_2"" type=""Dummies.SimpleDummy20"" singleton=""false"" />
<object name=""IDummy7_0"" type=""Dummies.SimpleDummy21"" singleton=""false"" />
<object name=""IDummy7_1"" type=""Dummies.SimpleDummy22"" singleton=""false"" />
<object name=""IDummy7_2"" type=""Dummies.SimpleDummy23"" singleton=""false"" />
<object name=""IDummy8_0"" type=""Dummies.SimpleDummy24"" singleton=""false"" />
<object name=""IDummy8_1"" type=""Dummies.SimpleDummy25"" singleton=""false"" />
<object name=""IDummy8_2"" type=""Dummies.SimpleDummy26"" singleton=""false"" />
<object name=""IDummy9_0"" type=""Dummies.SimpleDummy27"" singleton=""false"" />
<object name=""IDummy9_1"" type=""Dummies.SimpleDummy28"" singleton=""false"" />
<object name=""IDummy9_2"" type=""Dummies.SimpleDummy29"" singleton=""false"" />
<object name=""IDummy10_0"" type=""Dummies.SimpleDummy30"" singleton=""false"" />
<object name=""IDummy10_1"" type=""Dummies.SimpleDummy31"" singleton=""false"" />
<object name=""IDummy10_2"" type=""Dummies.SimpleDummy32"" singleton=""false"" />
<object name=""IDummy11_0"" type=""Dummies.SimpleDummy33"" singleton=""false"" />
<object name=""IDummy11_1"" type=""Dummies.SimpleDummy34"" singleton=""false"" />
<object name=""IDummy11_2"" type=""Dummies.SimpleDummy35"" singleton=""false"" />
<object name=""IDummy12_0"" type=""Dummies.SimpleDummy36"" singleton=""false"" />
<object name=""IDummy12_1"" type=""Dummies.SimpleDummy37"" singleton=""false"" />
<object name=""IDummy12_2"" type=""Dummies.SimpleDummy38"" singleton=""false"" />
<object name=""IDummy13_0"" type=""Dummies.SimpleDummy39"" singleton=""false"" />
<object name=""IDummy13_1"" type=""Dummies.SimpleDummy40"" singleton=""false"" />
<object name=""IDummy13_2"" type=""Dummies.SimpleDummy41"" singleton=""false"" />
<object name=""IDummy14_0"" type=""Dummies.SimpleDummy42"" singleton=""false"" />
<object name=""IDummy14_1"" type=""Dummies.SimpleDummy43"" singleton=""false"" />
<object name=""IDummy14_2"" type=""Dummies.SimpleDummy44"" singleton=""false"" />
<object name=""IDummy15_0"" type=""Dummies.SimpleDummy45"" singleton=""false"" />
<object name=""IDummy15_1"" type=""Dummies.SimpleDummy46"" singleton=""false"" />
<object name=""IDummy15_2"" type=""Dummies.SimpleDummy47"" singleton=""false"" />
<object name=""IDummy16_0"" type=""Dummies.SimpleDummy48"" singleton=""false"" />
<object name=""IDummy16_1"" type=""Dummies.SimpleDummy49"" singleton=""false"" />
<object name=""IDummy16_2"" type=""Dummies.SimpleDummy50"" singleton=""false"" />
<object name=""IDummy17_0"" type=""Dummies.SimpleDummy51"" singleton=""false"" />
<object name=""IDummy17_1"" type=""Dummies.SimpleDummy52"" singleton=""false"" />
<object name=""IDummy17_2"" type=""Dummies.SimpleDummy53"" singleton=""false"" />
<object name=""IDummy18_0"" type=""Dummies.SimpleDummy54"" singleton=""false"" />
<object name=""IDummy18_1"" type=""Dummies.SimpleDummy55"" singleton=""false"" />
<object name=""IDummy18_2"" type=""Dummies.SimpleDummy56"" singleton=""false"" />
<object name=""IDummy19_0"" type=""Dummies.SimpleDummy57"" singleton=""false"" />
<object name=""IDummy19_1"" type=""Dummies.SimpleDummy58"" singleton=""false"" />
<object name=""IDummy19_2"" type=""Dummies.SimpleDummy59"" singleton=""false"" />
<object name=""IDummy20_0"" type=""Dummies.SimpleDummy60"" singleton=""false"" />
<object name=""IDummy20_1"" type=""Dummies.SimpleDummy61"" singleton=""false"" />
<object name=""IDummy20_2"" type=""Dummies.SimpleDummy62"" singleton=""false"" />
<object name=""IDummy21_0"" type=""Dummies.SimpleDummy63"" singleton=""false"" />
<object name=""IDummy21_1"" type=""Dummies.SimpleDummy64"" singleton=""false"" />
<object name=""IDummy21_2"" type=""Dummies.SimpleDummy65"" singleton=""false"" />
<object name=""IDummy22_0"" type=""Dummies.SimpleDummy66"" singleton=""false"" />
<object name=""IDummy22_1"" type=""Dummies.SimpleDummy67"" singleton=""false"" />
<object name=""IDummy22_2"" type=""Dummies.SimpleDummy68"" singleton=""false"" />
<object name=""IDummy23_0"" type=""Dummies.SimpleDummy69"" singleton=""false"" />
<object name=""IDummy23_1"" type=""Dummies.SimpleDummy70"" singleton=""false"" />
<object name=""IDummy23_2"" type=""Dummies.SimpleDummy71"" singleton=""false"" />
<object name=""IDummy24_0"" type=""Dummies.SimpleDummy72"" singleton=""false"" />
<object name=""IDummy24_1"" type=""Dummies.SimpleDummy73"" singleton=""false"" />
<object name=""IDummy24_2"" type=""Dummies.SimpleDummy74"" singleton=""false"" />
<object name=""IDummy25_0"" type=""Dummies.SimpleDummy75"" singleton=""false"" />
<object name=""IDummy25_1"" type=""Dummies.SimpleDummy76"" singleton=""false"" />
<object name=""IDummy25_2"" type=""Dummies.SimpleDummy77"" singleton=""false"" />
<object name=""IDummy26_0"" type=""Dummies.SimpleDummy78"" singleton=""false"" />
<object name=""IDummy26_1"" type=""Dummies.SimpleDummy79"" singleton=""false"" />
<object name=""IDummy26_2"" type=""Dummies.SimpleDummy80"" singleton=""false"" />
<object name=""IDummy27_0"" type=""Dummies.SimpleDummy81"" singleton=""false"" />
<object name=""IDummy27_1"" type=""Dummies.SimpleDummy82"" singleton=""false"" />
<object name=""IDummy27_2"" type=""Dummies.SimpleDummy83"" singleton=""false"" />
<object name=""IDummy28_0"" type=""Dummies.SimpleDummy84"" singleton=""false"" />
<object name=""IDummy28_1"" type=""Dummies.SimpleDummy85"" singleton=""false"" />
<object name=""IDummy28_2"" type=""Dummies.SimpleDummy86"" singleton=""false"" />
<object name=""IDummy29_0"" type=""Dummies.SimpleDummy87"" singleton=""false"" />
<object name=""IDummy29_1"" type=""Dummies.SimpleDummy88"" singleton=""false"" />
<object name=""IDummy29_2"" type=""Dummies.SimpleDummy89"" singleton=""false"" />
<object name=""IDummy30_0"" type=""Dummies.SimpleDummy90"" singleton=""false"" />
<object name=""IDummy30_1"" type=""Dummies.SimpleDummy91"" singleton=""false"" />
<object name=""IDummy30_2"" type=""Dummies.SimpleDummy92"" singleton=""false"" />
<object name=""IDummy31_0"" type=""Dummies.SimpleDummy93"" singleton=""false"" />
<object name=""IDummy31_1"" type=""Dummies.SimpleDummy94"" singleton=""false"" />
<object name=""IDummy31_2"" type=""Dummies.SimpleDummy95"" singleton=""false"" />
<object name=""IDummy32_0"" type=""Dummies.SimpleDummy96"" singleton=""false"" />
<object name=""IDummy32_1"" type=""Dummies.SimpleDummy97"" singleton=""false"" />
<object name=""IDummy32_2"" type=""Dummies.SimpleDummy98"" singleton=""false"" />
<object name=""IDummy33_0"" type=""Dummies.SimpleDummy99"" singleton=""false"" />
<object name=""IDummy33_1"" type=""Dummies.SimpleDummy100"" singleton=""false"" />
<object name=""IDummy33_2"" type=""Dummies.SimpleDummy101"" singleton=""false"" />
<object name=""IDummy34_0"" type=""Dummies.SimpleDummy102"" singleton=""false"" />
<object name=""IDummy34_1"" type=""Dummies.SimpleDummy103"" singleton=""false"" />
<object name=""IDummy34_2"" type=""Dummies.SimpleDummy104"" singleton=""false"" />
<object name=""IDummy35_0"" type=""Dummies.SimpleDummy105"" singleton=""false"" />
<object name=""IDummy35_1"" type=""Dummies.SimpleDummy106"" singleton=""false"" />
<object name=""IDummy35_2"" type=""Dummies.SimpleDummy107"" singleton=""false"" />
<object name=""IDummy36_0"" type=""Dummies.SimpleDummy108"" singleton=""false"" />
<object name=""IDummy36_1"" type=""Dummies.SimpleDummy109"" singleton=""false"" />
<object name=""IDummy36_2"" type=""Dummies.SimpleDummy110"" singleton=""false"" />
<object name=""IDummy37_0"" type=""Dummies.SimpleDummy111"" singleton=""false"" />
<object name=""IDummy37_1"" type=""Dummies.SimpleDummy112"" singleton=""false"" />
<object name=""IDummy37_2"" type=""Dummies.SimpleDummy113"" singleton=""false"" />
<object name=""IDummy38_0"" type=""Dummies.SimpleDummy114"" singleton=""false"" />
<object name=""IDummy38_1"" type=""Dummies.SimpleDummy115"" singleton=""false"" />
<object name=""IDummy38_2"" type=""Dummies.SimpleDummy116"" singleton=""false"" />
<object name=""IDummy39_0"" type=""Dummies.SimpleDummy117"" singleton=""false"" />
<object name=""IDummy39_1"" type=""Dummies.SimpleDummy118"" singleton=""false"" />
<object name=""IDummy39_2"" type=""Dummies.SimpleDummy119"" singleton=""false"" />
<object name=""IDummy40_0"" type=""Dummies.SimpleDummy120"" singleton=""false"" />
<object name=""IDummy40_1"" type=""Dummies.SimpleDummy121"" singleton=""false"" />
<object name=""IDummy40_2"" type=""Dummies.SimpleDummy122"" singleton=""false"" />
<object name=""IDummy41_0"" type=""Dummies.SimpleDummy123"" singleton=""false"" />
<object name=""IDummy41_1"" type=""Dummies.SimpleDummy124"" singleton=""false"" />
<object name=""IDummy41_2"" type=""Dummies.SimpleDummy125"" singleton=""false"" />
<object name=""IDummy42_0"" type=""Dummies.SimpleDummy126"" singleton=""false"" />
<object name=""IDummy42_1"" type=""Dummies.SimpleDummy127"" singleton=""false"" />
<object name=""IDummy42_2"" type=""Dummies.SimpleDummy128"" singleton=""false"" />
<object name=""IDummy43_0"" type=""Dummies.SimpleDummy129"" singleton=""false"" />
<object name=""IDummy43_1"" type=""Dummies.SimpleDummy130"" singleton=""false"" />
<object name=""IDummy43_2"" type=""Dummies.SimpleDummy131"" singleton=""false"" />
<object name=""IDummy44_0"" type=""Dummies.SimpleDummy132"" singleton=""false"" />
<object name=""IDummy44_1"" type=""Dummies.SimpleDummy133"" singleton=""false"" />
<object name=""IDummy44_2"" type=""Dummies.SimpleDummy134"" singleton=""false"" />
<object name=""IDummy45_0"" type=""Dummies.SimpleDummy135"" singleton=""false"" />
<object name=""IDummy45_1"" type=""Dummies.SimpleDummy136"" singleton=""false"" />
<object name=""IDummy45_2"" type=""Dummies.SimpleDummy137"" singleton=""false"" />
<object name=""IDummy46_0"" type=""Dummies.SimpleDummy138"" singleton=""false"" />
<object name=""IDummy46_1"" type=""Dummies.SimpleDummy139"" singleton=""false"" />
<object name=""IDummy46_2"" type=""Dummies.SimpleDummy140"" singleton=""false"" />
<object name=""IDummy47_0"" type=""Dummies.SimpleDummy141"" singleton=""false"" />
<object name=""IDummy47_1"" type=""Dummies.SimpleDummy142"" singleton=""false"" />
<object name=""IDummy47_2"" type=""Dummies.SimpleDummy143"" singleton=""false"" />
<object name=""IDummy48_0"" type=""Dummies.SimpleDummy144"" singleton=""false"" />
<object name=""IDummy48_1"" type=""Dummies.SimpleDummy145"" singleton=""false"" />
<object name=""IDummy48_2"" type=""Dummies.SimpleDummy146"" singleton=""false"" />
<object name=""IDummy49_0"" type=""Dummies.SimpleDummy147"" singleton=""false"" />
<object name=""IDummy49_1"" type=""Dummies.SimpleDummy148"" singleton=""false"" />
<object name=""IDummy49_2"" type=""Dummies.SimpleDummy149"" singleton=""false"" />
<object name=""IDummy50_0"" type=""Dummies.SimpleDummy150"" singleton=""false"" />
<object name=""IDummy50_1"" type=""Dummies.SimpleDummy151"" singleton=""false"" />
<object name=""IDummy50_2"" type=""Dummies.SimpleDummy152"" singleton=""false"" />
<object name=""IDummy51_0"" type=""Dummies.SimpleDummy153"" singleton=""false"" />
<object name=""IDummy51_1"" type=""Dummies.SimpleDummy154"" singleton=""false"" />
<object name=""IDummy51_2"" type=""Dummies.SimpleDummy155"" singleton=""false"" />
<object name=""IDummy52_0"" type=""Dummies.SimpleDummy156"" singleton=""false"" />
<object name=""IDummy52_1"" type=""Dummies.SimpleDummy157"" singleton=""false"" />
<object name=""IDummy52_2"" type=""Dummies.SimpleDummy158"" singleton=""false"" />
<object name=""IDummy53_0"" type=""Dummies.SimpleDummy159"" singleton=""false"" />
<object name=""IDummy53_1"" type=""Dummies.SimpleDummy160"" singleton=""false"" />
<object name=""IDummy53_2"" type=""Dummies.SimpleDummy161"" singleton=""false"" />
<object name=""IDummy54_0"" type=""Dummies.SimpleDummy162"" singleton=""false"" />
<object name=""IDummy54_1"" type=""Dummies.SimpleDummy163"" singleton=""false"" />
<object name=""IDummy54_2"" type=""Dummies.SimpleDummy164"" singleton=""false"" />
<object name=""IDummy55_0"" type=""Dummies.SimpleDummy165"" singleton=""false"" />
<object name=""IDummy55_1"" type=""Dummies.SimpleDummy166"" singleton=""false"" />
<object name=""IDummy55_2"" type=""Dummies.SimpleDummy167"" singleton=""false"" />
<object name=""IDummy56_0"" type=""Dummies.SimpleDummy168"" singleton=""false"" />
<object name=""IDummy56_1"" type=""Dummies.SimpleDummy169"" singleton=""false"" />
<object name=""IDummy56_2"" type=""Dummies.SimpleDummy170"" singleton=""false"" />
<object name=""IDummy57_0"" type=""Dummies.SimpleDummy171"" singleton=""false"" />
<object name=""IDummy57_1"" type=""Dummies.SimpleDummy172"" singleton=""false"" />
<object name=""IDummy57_2"" type=""Dummies.SimpleDummy173"" singleton=""false"" />
<object name=""IDummy58_0"" type=""Dummies.SimpleDummy174"" singleton=""false"" />
<object name=""IDummy58_1"" type=""Dummies.SimpleDummy175"" singleton=""false"" />
<object name=""IDummy58_2"" type=""Dummies.SimpleDummy176"" singleton=""false"" />
<object name=""IDummy59_0"" type=""Dummies.SimpleDummy177"" singleton=""false"" />
<object name=""IDummy59_1"" type=""Dummies.SimpleDummy178"" singleton=""false"" />
<object name=""IDummy59_2"" type=""Dummies.SimpleDummy179"" singleton=""false"" />
<object name=""IDummy60_0"" type=""Dummies.SimpleDummy180"" singleton=""false"" />
<object name=""IDummy60_1"" type=""Dummies.SimpleDummy181"" singleton=""false"" />
<object name=""IDummy60_2"" type=""Dummies.SimpleDummy182"" singleton=""false"" />
<object name=""IDummy61_0"" type=""Dummies.SimpleDummy183"" singleton=""false"" />
<object name=""IDummy61_1"" type=""Dummies.SimpleDummy184"" singleton=""false"" />
<object name=""IDummy61_2"" type=""Dummies.SimpleDummy185"" singleton=""false"" />
<object name=""IDummy62_0"" type=""Dummies.SimpleDummy186"" singleton=""false"" />
<object name=""IDummy62_1"" type=""Dummies.SimpleDummy187"" singleton=""false"" />
<object name=""IDummy62_2"" type=""Dummies.SimpleDummy188"" singleton=""false"" />
<object name=""IDummy63_0"" type=""Dummies.SimpleDummy189"" singleton=""false"" />
<object name=""IDummy63_1"" type=""Dummies.SimpleDummy190"" singleton=""false"" />
<object name=""IDummy63_2"" type=""Dummies.SimpleDummy191"" singleton=""false"" />
<object name=""IDummy64_0"" type=""Dummies.SimpleDummy192"" singleton=""false"" />
<object name=""IDummy64_1"" type=""Dummies.SimpleDummy193"" singleton=""false"" />
<object name=""IDummy64_2"" type=""Dummies.SimpleDummy194"" singleton=""false"" />
<object name=""IDummy65_0"" type=""Dummies.SimpleDummy195"" singleton=""false"" />
<object name=""IDummy65_1"" type=""Dummies.SimpleDummy196"" singleton=""false"" />
<object name=""IDummy65_2"" type=""Dummies.SimpleDummy197"" singleton=""false"" />
<object name=""IDummy66_0"" type=""Dummies.SimpleDummy198"" singleton=""false"" />
<object name=""IDummy66_1"" type=""Dummies.SimpleDummy199"" singleton=""false"" />
<object name=""IDummy66_2"" type=""Dummies.SimpleDummy200"" singleton=""false"" />
<object name=""IDummy67_0"" type=""Dummies.SimpleDummy201"" singleton=""false"" />
<object name=""IDummy67_1"" type=""Dummies.SimpleDummy202"" singleton=""false"" />
<object name=""IDummy67_2"" type=""Dummies.SimpleDummy203"" singleton=""false"" />
<object name=""IDummy68_0"" type=""Dummies.SimpleDummy204"" singleton=""false"" />
<object name=""IDummy68_1"" type=""Dummies.SimpleDummy205"" singleton=""false"" />
<object name=""IDummy68_2"" type=""Dummies.SimpleDummy206"" singleton=""false"" />
<object name=""IDummy69_0"" type=""Dummies.SimpleDummy207"" singleton=""false"" />
<object name=""IDummy69_1"" type=""Dummies.SimpleDummy208"" singleton=""false"" />
<object name=""IDummy69_2"" type=""Dummies.SimpleDummy209"" singleton=""false"" />
<object name=""IDummy70_0"" type=""Dummies.SimpleDummy210"" singleton=""false"" />
<object name=""IDummy70_1"" type=""Dummies.SimpleDummy211"" singleton=""false"" />
<object name=""IDummy70_2"" type=""Dummies.SimpleDummy212"" singleton=""false"" />
<object name=""IDummy71_0"" type=""Dummies.SimpleDummy213"" singleton=""false"" />
<object name=""IDummy71_1"" type=""Dummies.SimpleDummy214"" singleton=""false"" />
<object name=""IDummy71_2"" type=""Dummies.SimpleDummy215"" singleton=""false"" />
<object name=""IDummy72_0"" type=""Dummies.SimpleDummy216"" singleton=""false"" />
<object name=""IDummy72_1"" type=""Dummies.SimpleDummy217"" singleton=""false"" />
<object name=""IDummy72_2"" type=""Dummies.SimpleDummy218"" singleton=""false"" />
<object name=""IDummy73_0"" type=""Dummies.SimpleDummy219"" singleton=""false"" />
<object name=""IDummy73_1"" type=""Dummies.SimpleDummy220"" singleton=""false"" />
<object name=""IDummy73_2"" type=""Dummies.SimpleDummy221"" singleton=""false"" />
<object name=""IDummy74_0"" type=""Dummies.SimpleDummy222"" singleton=""false"" />
<object name=""IDummy74_1"" type=""Dummies.SimpleDummy223"" singleton=""false"" />
<object name=""IDummy74_2"" type=""Dummies.SimpleDummy224"" singleton=""false"" />
<object name=""IDummy75_0"" type=""Dummies.SimpleDummy225"" singleton=""false"" />
<object name=""IDummy75_1"" type=""Dummies.SimpleDummy226"" singleton=""false"" />
<object name=""IDummy75_2"" type=""Dummies.SimpleDummy227"" singleton=""false"" />
<object name=""IDummy76_0"" type=""Dummies.SimpleDummy228"" singleton=""false"" />
<object name=""IDummy76_1"" type=""Dummies.SimpleDummy229"" singleton=""false"" />
<object name=""IDummy76_2"" type=""Dummies.SimpleDummy230"" singleton=""false"" />
<object name=""IDummy77_0"" type=""Dummies.SimpleDummy231"" singleton=""false"" />
<object name=""IDummy77_1"" type=""Dummies.SimpleDummy232"" singleton=""false"" />
<object name=""IDummy77_2"" type=""Dummies.SimpleDummy233"" singleton=""false"" />
<object name=""IDummy78_0"" type=""Dummies.SimpleDummy234"" singleton=""false"" />
<object name=""IDummy78_1"" type=""Dummies.SimpleDummy235"" singleton=""false"" />
<object name=""IDummy78_2"" type=""Dummies.SimpleDummy236"" singleton=""false"" />
<object name=""IDummy79_0"" type=""Dummies.SimpleDummy237"" singleton=""false"" />
<object name=""IDummy79_1"" type=""Dummies.SimpleDummy238"" singleton=""false"" />
<object name=""IDummy79_2"" type=""Dummies.SimpleDummy239"" singleton=""false"" />
<object name=""IDummy80_0"" type=""Dummies.SimpleDummy240"" singleton=""false"" />
<object name=""IDummy80_1"" type=""Dummies.SimpleDummy241"" singleton=""false"" />
<object name=""IDummy80_2"" type=""Dummies.SimpleDummy242"" singleton=""false"" />
<object name=""IDummy81_0"" type=""Dummies.SimpleDummy243"" singleton=""false"" />
<object name=""IDummy81_1"" type=""Dummies.SimpleDummy244"" singleton=""false"" />
<object name=""IDummy81_2"" type=""Dummies.SimpleDummy245"" singleton=""false"" />
<object name=""IDummy82_0"" type=""Dummies.SimpleDummy246"" singleton=""false"" />
<object name=""IDummy82_1"" type=""Dummies.SimpleDummy247"" singleton=""false"" />
<object name=""IDummy82_2"" type=""Dummies.SimpleDummy248"" singleton=""false"" />
<object name=""IDummy83_0"" type=""Dummies.SimpleDummy249"" singleton=""false"" />
<object name=""IDummy83_1"" type=""Dummies.SimpleDummy250"" singleton=""false"" />
<object name=""IDummy83_2"" type=""Dummies.SimpleDummy251"" singleton=""false"" />
<object name=""IDummy84_0"" type=""Dummies.SimpleDummy252"" singleton=""false"" />
<object name=""IDummy84_1"" type=""Dummies.SimpleDummy253"" singleton=""false"" />
<object name=""IDummy84_2"" type=""Dummies.SimpleDummy254"" singleton=""false"" />
<object name=""IDummy85_0"" type=""Dummies.SimpleDummy255"" singleton=""false"" />
<object name=""IDummy85_1"" type=""Dummies.SimpleDummy256"" singleton=""false"" />
<object name=""IDummy85_2"" type=""Dummies.SimpleDummy257"" singleton=""false"" />
<object name=""IDummy86_0"" type=""Dummies.SimpleDummy258"" singleton=""false"" />
<object name=""IDummy86_1"" type=""Dummies.SimpleDummy259"" singleton=""false"" />
<object name=""IDummy86_2"" type=""Dummies.SimpleDummy260"" singleton=""false"" />
<object name=""IDummy87_0"" type=""Dummies.SimpleDummy261"" singleton=""false"" />
<object name=""IDummy87_1"" type=""Dummies.SimpleDummy262"" singleton=""false"" />
<object name=""IDummy87_2"" type=""Dummies.SimpleDummy263"" singleton=""false"" />
<object name=""IDummy88_0"" type=""Dummies.SimpleDummy264"" singleton=""false"" />
<object name=""IDummy88_1"" type=""Dummies.SimpleDummy265"" singleton=""false"" />
<object name=""IDummy88_2"" type=""Dummies.SimpleDummy266"" singleton=""false"" />
<object name=""IDummy89_0"" type=""Dummies.SimpleDummy267"" singleton=""false"" />
<object name=""IDummy89_1"" type=""Dummies.SimpleDummy268"" singleton=""false"" />
<object name=""IDummy89_2"" type=""Dummies.SimpleDummy269"" singleton=""false"" />
<object name=""IDummy90_0"" type=""Dummies.SimpleDummy270"" singleton=""false"" />
<object name=""IDummy90_1"" type=""Dummies.SimpleDummy271"" singleton=""false"" />
<object name=""IDummy90_2"" type=""Dummies.SimpleDummy272"" singleton=""false"" />
<object name=""IDummy91_0"" type=""Dummies.SimpleDummy273"" singleton=""false"" />
<object name=""IDummy91_1"" type=""Dummies.SimpleDummy274"" singleton=""false"" />
<object name=""IDummy91_2"" type=""Dummies.SimpleDummy275"" singleton=""false"" />
<object name=""IDummy92_0"" type=""Dummies.SimpleDummy276"" singleton=""false"" />
<object name=""IDummy92_1"" type=""Dummies.SimpleDummy277"" singleton=""false"" />
<object name=""IDummy92_2"" type=""Dummies.SimpleDummy278"" singleton=""false"" />
<object name=""IDummy93_0"" type=""Dummies.SimpleDummy279"" singleton=""false"" />
<object name=""IDummy93_1"" type=""Dummies.SimpleDummy280"" singleton=""false"" />
<object name=""IDummy93_2"" type=""Dummies.SimpleDummy281"" singleton=""false"" />
<object name=""IDummy94_0"" type=""Dummies.SimpleDummy282"" singleton=""false"" />
<object name=""IDummy94_1"" type=""Dummies.SimpleDummy283"" singleton=""false"" />
<object name=""IDummy94_2"" type=""Dummies.SimpleDummy284"" singleton=""false"" />
<object name=""IDummy95_0"" type=""Dummies.SimpleDummy285"" singleton=""false"" />
<object name=""IDummy95_1"" type=""Dummies.SimpleDummy286"" singleton=""false"" />
<object name=""IDummy95_2"" type=""Dummies.SimpleDummy287"" singleton=""false"" />
<object name=""IDummy96_0"" type=""Dummies.SimpleDummy288"" singleton=""false"" />
<object name=""IDummy96_1"" type=""Dummies.SimpleDummy289"" singleton=""false"" />
<object name=""IDummy96_2"" type=""Dummies.SimpleDummy290"" singleton=""false"" />
<object name=""IDummy97_0"" type=""Dummies.SimpleDummy291"" singleton=""false"" />
<object name=""IDummy97_1"" type=""Dummies.SimpleDummy292"" singleton=""false"" />
<object name=""IDummy97_2"" type=""Dummies.SimpleDummy293"" singleton=""false"" />
<object name=""IDummy98_0"" type=""Dummies.SimpleDummy294"" singleton=""false"" />
<object name=""IDummy98_1"" type=""Dummies.SimpleDummy295"" singleton=""false"" />
<object name=""IDummy98_2"" type=""Dummies.SimpleDummy296"" singleton=""false"" />
<object name=""IDummy99_0"" type=""Dummies.SimpleDummy297"" singleton=""false"" />
<object name=""IDummy99_1"" type=""Dummies.SimpleDummy298"" singleton=""false"" />
<object name=""IDummy99_2"" type=""Dummies.SimpleDummy299"" singleton=""false"" />
<object name=""IDummy100_0"" type=""Dummies.SimpleDummy300"" singleton=""false"" />
<object name=""IDummy100_1"" type=""Dummies.SimpleDummy301"" singleton=""false"" />
<object name=""IDummy100_2"" type=""Dummies.SimpleDummy302"" singleton=""false"" />
<object name=""IDummy101_0"" type=""Dummies.SimpleDummy303"" singleton=""false"" />
<object name=""IDummy101_1"" type=""Dummies.SimpleDummy304"" singleton=""false"" />
<object name=""IDummy101_2"" type=""Dummies.SimpleDummy305"" singleton=""false"" />
<object name=""IDummy102_0"" type=""Dummies.SimpleDummy306"" singleton=""false"" />
<object name=""IDummy102_1"" type=""Dummies.SimpleDummy307"" singleton=""false"" />
<object name=""IDummy102_2"" type=""Dummies.SimpleDummy308"" singleton=""false"" />
<object name=""IDummy103_0"" type=""Dummies.SimpleDummy309"" singleton=""false"" />
<object name=""IDummy103_1"" type=""Dummies.SimpleDummy310"" singleton=""false"" />
<object name=""IDummy103_2"" type=""Dummies.SimpleDummy311"" singleton=""false"" />
<object name=""IDummy104_0"" type=""Dummies.SimpleDummy312"" singleton=""false"" />
<object name=""IDummy104_1"" type=""Dummies.SimpleDummy313"" singleton=""false"" />
<object name=""IDummy104_2"" type=""Dummies.SimpleDummy314"" singleton=""false"" />
<object name=""IDummy105_0"" type=""Dummies.SimpleDummy315"" singleton=""false"" />
<object name=""IDummy105_1"" type=""Dummies.SimpleDummy316"" singleton=""false"" />
<object name=""IDummy105_2"" type=""Dummies.SimpleDummy317"" singleton=""false"" />
<object name=""IDummy106_0"" type=""Dummies.SimpleDummy318"" singleton=""false"" />
<object name=""IDummy106_1"" type=""Dummies.SimpleDummy319"" singleton=""false"" />
<object name=""IDummy106_2"" type=""Dummies.SimpleDummy320"" singleton=""false"" />
<object name=""IDummy107_0"" type=""Dummies.SimpleDummy321"" singleton=""false"" />
<object name=""IDummy107_1"" type=""Dummies.SimpleDummy322"" singleton=""false"" />
<object name=""IDummy107_2"" type=""Dummies.SimpleDummy323"" singleton=""false"" />
<object name=""IDummy108_0"" type=""Dummies.SimpleDummy324"" singleton=""false"" />
<object name=""IDummy108_1"" type=""Dummies.SimpleDummy325"" singleton=""false"" />
<object name=""IDummy108_2"" type=""Dummies.SimpleDummy326"" singleton=""false"" />
<object name=""IDummy109_0"" type=""Dummies.SimpleDummy327"" singleton=""false"" />
<object name=""IDummy109_1"" type=""Dummies.SimpleDummy328"" singleton=""false"" />
<object name=""IDummy109_2"" type=""Dummies.SimpleDummy329"" singleton=""false"" />
<object name=""IDummy110_0"" type=""Dummies.SimpleDummy330"" singleton=""false"" />
<object name=""IDummy110_1"" type=""Dummies.SimpleDummy331"" singleton=""false"" />
<object name=""IDummy110_2"" type=""Dummies.SimpleDummy332"" singleton=""false"" />
<object name=""IDummy111_0"" type=""Dummies.SimpleDummy333"" singleton=""false"" />
<object name=""IDummy111_1"" type=""Dummies.SimpleDummy334"" singleton=""false"" />
<object name=""IDummy111_2"" type=""Dummies.SimpleDummy335"" singleton=""false"" />
<object name=""IDummy112_0"" type=""Dummies.SimpleDummy336"" singleton=""false"" />
<object name=""IDummy112_1"" type=""Dummies.SimpleDummy337"" singleton=""false"" />
<object name=""IDummy112_2"" type=""Dummies.SimpleDummy338"" singleton=""false"" />
<object name=""IDummy113_0"" type=""Dummies.SimpleDummy339"" singleton=""false"" />
<object name=""IDummy113_1"" type=""Dummies.SimpleDummy340"" singleton=""false"" />
<object name=""IDummy113_2"" type=""Dummies.SimpleDummy341"" singleton=""false"" />
<object name=""IDummy114_0"" type=""Dummies.SimpleDummy342"" singleton=""false"" />
<object name=""IDummy114_1"" type=""Dummies.SimpleDummy343"" singleton=""false"" />
<object name=""IDummy114_2"" type=""Dummies.SimpleDummy344"" singleton=""false"" />
<object name=""IDummy115_0"" type=""Dummies.SimpleDummy345"" singleton=""false"" />
<object name=""IDummy115_1"" type=""Dummies.SimpleDummy346"" singleton=""false"" />
<object name=""IDummy115_2"" type=""Dummies.SimpleDummy347"" singleton=""false"" />
<object name=""IDummy116_0"" type=""Dummies.SimpleDummy348"" singleton=""false"" />
<object name=""IDummy116_1"" type=""Dummies.SimpleDummy349"" singleton=""false"" />
<object name=""IDummy116_2"" type=""Dummies.SimpleDummy350"" singleton=""false"" />
<object name=""IDummy117_0"" type=""Dummies.SimpleDummy351"" singleton=""false"" />
<object name=""IDummy117_1"" type=""Dummies.SimpleDummy352"" singleton=""false"" />
<object name=""IDummy117_2"" type=""Dummies.SimpleDummy353"" singleton=""false"" />
<object name=""IDummy118_0"" type=""Dummies.SimpleDummy354"" singleton=""false"" />
<object name=""IDummy118_1"" type=""Dummies.SimpleDummy355"" singleton=""false"" />
<object name=""IDummy118_2"" type=""Dummies.SimpleDummy356"" singleton=""false"" />
<object name=""IDummy119_0"" type=""Dummies.SimpleDummy357"" singleton=""false"" />
<object name=""IDummy119_1"" type=""Dummies.SimpleDummy358"" singleton=""false"" />
<object name=""IDummy119_2"" type=""Dummies.SimpleDummy359"" singleton=""false"" />
<object name=""IDummy120_0"" type=""Dummies.SimpleDummy360"" singleton=""false"" />
<object name=""IDummy120_1"" type=""Dummies.SimpleDummy361"" singleton=""false"" />
<object name=""IDummy120_2"" type=""Dummies.SimpleDummy362"" singleton=""false"" />
<object name=""IDummy121_0"" type=""Dummies.SimpleDummy363"" singleton=""false"" />
<object name=""IDummy121_1"" type=""Dummies.SimpleDummy364"" singleton=""false"" />
<object name=""IDummy121_2"" type=""Dummies.SimpleDummy365"" singleton=""false"" />
<object name=""IDummy122_0"" type=""Dummies.SimpleDummy366"" singleton=""false"" />
<object name=""IDummy122_1"" type=""Dummies.SimpleDummy367"" singleton=""false"" />
<object name=""IDummy122_2"" type=""Dummies.SimpleDummy368"" singleton=""false"" />
<object name=""IDummy123_0"" type=""Dummies.SimpleDummy369"" singleton=""false"" />
<object name=""IDummy123_1"" type=""Dummies.SimpleDummy370"" singleton=""false"" />
<object name=""IDummy123_2"" type=""Dummies.SimpleDummy371"" singleton=""false"" />
<object name=""IDummy124_0"" type=""Dummies.SimpleDummy372"" singleton=""false"" />
<object name=""IDummy124_1"" type=""Dummies.SimpleDummy373"" singleton=""false"" />
<object name=""IDummy124_2"" type=""Dummies.SimpleDummy374"" singleton=""false"" />
<object name=""IDummy125_0"" type=""Dummies.SimpleDummy375"" singleton=""false"" />
<object name=""IDummy125_1"" type=""Dummies.SimpleDummy376"" singleton=""false"" />
<object name=""IDummy125_2"" type=""Dummies.SimpleDummy377"" singleton=""false"" />
<object name=""IDummy126_0"" type=""Dummies.SimpleDummy378"" singleton=""false"" />
<object name=""IDummy126_1"" type=""Dummies.SimpleDummy379"" singleton=""false"" />
<object name=""IDummy126_2"" type=""Dummies.SimpleDummy380"" singleton=""false"" />
<object name=""IDummy127_0"" type=""Dummies.SimpleDummy381"" singleton=""false"" />
<object name=""IDummy127_1"" type=""Dummies.SimpleDummy382"" singleton=""false"" />
<object name=""IDummy127_2"" type=""Dummies.SimpleDummy383"" singleton=""false"" />
<object name=""IDummy128_0"" type=""Dummies.SimpleDummy384"" singleton=""false"" />
<object name=""IDummy128_1"" type=""Dummies.SimpleDummy385"" singleton=""false"" />
<object name=""IDummy128_2"" type=""Dummies.SimpleDummy386"" singleton=""false"" />
<object name=""IDummy129_0"" type=""Dummies.SimpleDummy387"" singleton=""false"" />
<object name=""IDummy129_1"" type=""Dummies.SimpleDummy388"" singleton=""false"" />
<object name=""IDummy129_2"" type=""Dummies.SimpleDummy389"" singleton=""false"" />
<object name=""IDummy130_0"" type=""Dummies.SimpleDummy390"" singleton=""false"" />
<object name=""IDummy130_1"" type=""Dummies.SimpleDummy391"" singleton=""false"" />
<object name=""IDummy130_2"" type=""Dummies.SimpleDummy392"" singleton=""false"" />
<object name=""IDummy131_0"" type=""Dummies.SimpleDummy393"" singleton=""false"" />
<object name=""IDummy131_1"" type=""Dummies.SimpleDummy394"" singleton=""false"" />
<object name=""IDummy131_2"" type=""Dummies.SimpleDummy395"" singleton=""false"" />
<object name=""IDummy132_0"" type=""Dummies.SimpleDummy396"" singleton=""false"" />
<object name=""IDummy132_1"" type=""Dummies.SimpleDummy397"" singleton=""false"" />
<object name=""IDummy132_2"" type=""Dummies.SimpleDummy398"" singleton=""false"" />
<object name=""IDummy133_0"" type=""Dummies.SimpleDummy399"" singleton=""false"" />
<object name=""IDummy133_1"" type=""Dummies.SimpleDummy400"" singleton=""false"" />
<object name=""IDummy133_2"" type=""Dummies.SimpleDummy401"" singleton=""false"" />
<object name=""IDummy134_0"" type=""Dummies.SimpleDummy402"" singleton=""false"" />
<object name=""IDummy134_1"" type=""Dummies.SimpleDummy403"" singleton=""false"" />
<object name=""IDummy134_2"" type=""Dummies.SimpleDummy404"" singleton=""false"" />
<object name=""IDummy135_0"" type=""Dummies.SimpleDummy405"" singleton=""false"" />
<object name=""IDummy135_1"" type=""Dummies.SimpleDummy406"" singleton=""false"" />
<object name=""IDummy135_2"" type=""Dummies.SimpleDummy407"" singleton=""false"" />
<object name=""IDummy136_0"" type=""Dummies.SimpleDummy408"" singleton=""false"" />
<object name=""IDummy136_1"" type=""Dummies.SimpleDummy409"" singleton=""false"" />
<object name=""IDummy136_2"" type=""Dummies.SimpleDummy410"" singleton=""false"" />
<object name=""IDummy137_0"" type=""Dummies.SimpleDummy411"" singleton=""false"" />
<object name=""IDummy137_1"" type=""Dummies.SimpleDummy412"" singleton=""false"" />
<object name=""IDummy137_2"" type=""Dummies.SimpleDummy413"" singleton=""false"" />
<object name=""IDummy138_0"" type=""Dummies.SimpleDummy414"" singleton=""false"" />
<object name=""IDummy138_1"" type=""Dummies.SimpleDummy415"" singleton=""false"" />
<object name=""IDummy138_2"" type=""Dummies.SimpleDummy416"" singleton=""false"" />
<object name=""IDummy139_0"" type=""Dummies.SimpleDummy417"" singleton=""false"" />
<object name=""IDummy139_1"" type=""Dummies.SimpleDummy418"" singleton=""false"" />
<object name=""IDummy139_2"" type=""Dummies.SimpleDummy419"" singleton=""false"" />
<object name=""IDummy140_0"" type=""Dummies.SimpleDummy420"" singleton=""false"" />
<object name=""IDummy140_1"" type=""Dummies.SimpleDummy421"" singleton=""false"" />
<object name=""IDummy140_2"" type=""Dummies.SimpleDummy422"" singleton=""false"" />
<object name=""IDummy141_0"" type=""Dummies.SimpleDummy423"" singleton=""false"" />
<object name=""IDummy141_1"" type=""Dummies.SimpleDummy424"" singleton=""false"" />
<object name=""IDummy141_2"" type=""Dummies.SimpleDummy425"" singleton=""false"" />
<object name=""IDummy142_0"" type=""Dummies.SimpleDummy426"" singleton=""false"" />
<object name=""IDummy142_1"" type=""Dummies.SimpleDummy427"" singleton=""false"" />
<object name=""IDummy142_2"" type=""Dummies.SimpleDummy428"" singleton=""false"" />
<object name=""IDummy143_0"" type=""Dummies.SimpleDummy429"" singleton=""false"" />
<object name=""IDummy143_1"" type=""Dummies.SimpleDummy430"" singleton=""false"" />
<object name=""IDummy143_2"" type=""Dummies.SimpleDummy431"" singleton=""false"" />
<object name=""IDummy144_0"" type=""Dummies.SimpleDummy432"" singleton=""false"" />
<object name=""IDummy144_1"" type=""Dummies.SimpleDummy433"" singleton=""false"" />
<object name=""IDummy144_2"" type=""Dummies.SimpleDummy434"" singleton=""false"" />
<object name=""IDummy145_0"" type=""Dummies.SimpleDummy435"" singleton=""false"" />
<object name=""IDummy145_1"" type=""Dummies.SimpleDummy436"" singleton=""false"" />
<object name=""IDummy145_2"" type=""Dummies.SimpleDummy437"" singleton=""false"" />
<object name=""IDummy146_0"" type=""Dummies.SimpleDummy438"" singleton=""false"" />
<object name=""IDummy146_1"" type=""Dummies.SimpleDummy439"" singleton=""false"" />
<object name=""IDummy146_2"" type=""Dummies.SimpleDummy440"" singleton=""false"" />
<object name=""IDummy147_0"" type=""Dummies.SimpleDummy441"" singleton=""false"" />
<object name=""IDummy147_1"" type=""Dummies.SimpleDummy442"" singleton=""false"" />
<object name=""IDummy147_2"" type=""Dummies.SimpleDummy443"" singleton=""false"" />
<object name=""IDummy148_0"" type=""Dummies.SimpleDummy444"" singleton=""false"" />
<object name=""IDummy148_1"" type=""Dummies.SimpleDummy445"" singleton=""false"" />
<object name=""IDummy148_2"" type=""Dummies.SimpleDummy446"" singleton=""false"" />
<object name=""IDummy149_0"" type=""Dummies.SimpleDummy447"" singleton=""false"" />
<object name=""IDummy149_1"" type=""Dummies.SimpleDummy448"" singleton=""false"" />
<object name=""IDummy149_2"" type=""Dummies.SimpleDummy449"" singleton=""false"" />
<object name=""IDummy150_0"" type=""Dummies.SimpleDummy450"" singleton=""false"" />
<object name=""IDummy150_1"" type=""Dummies.SimpleDummy451"" singleton=""false"" />
<object name=""IDummy150_2"" type=""Dummies.SimpleDummy452"" singleton=""false"" />
<object name=""IDummy151_0"" type=""Dummies.SimpleDummy453"" singleton=""false"" />
<object name=""IDummy151_1"" type=""Dummies.SimpleDummy454"" singleton=""false"" />
<object name=""IDummy151_2"" type=""Dummies.SimpleDummy455"" singleton=""false"" />
<object name=""IDummy152_0"" type=""Dummies.SimpleDummy456"" singleton=""false"" />
<object name=""IDummy152_1"" type=""Dummies.SimpleDummy457"" singleton=""false"" />
<object name=""IDummy152_2"" type=""Dummies.SimpleDummy458"" singleton=""false"" />
<object name=""IDummy153_0"" type=""Dummies.SimpleDummy459"" singleton=""false"" />
<object name=""IDummy153_1"" type=""Dummies.SimpleDummy460"" singleton=""false"" />
<object name=""IDummy153_2"" type=""Dummies.SimpleDummy461"" singleton=""false"" />
<object name=""IDummy154_0"" type=""Dummies.SimpleDummy462"" singleton=""false"" />
<object name=""IDummy154_1"" type=""Dummies.SimpleDummy463"" singleton=""false"" />
<object name=""IDummy154_2"" type=""Dummies.SimpleDummy464"" singleton=""false"" />
<object name=""IDummy155_0"" type=""Dummies.SimpleDummy465"" singleton=""false"" />
<object name=""IDummy155_1"" type=""Dummies.SimpleDummy466"" singleton=""false"" />
<object name=""IDummy155_2"" type=""Dummies.SimpleDummy467"" singleton=""false"" />
<object name=""IDummy156_0"" type=""Dummies.SimpleDummy468"" singleton=""false"" />
<object name=""IDummy156_1"" type=""Dummies.SimpleDummy469"" singleton=""false"" />
<object name=""IDummy156_2"" type=""Dummies.SimpleDummy470"" singleton=""false"" />
<object name=""IDummy157_0"" type=""Dummies.SimpleDummy471"" singleton=""false"" />
<object name=""IDummy157_1"" type=""Dummies.SimpleDummy472"" singleton=""false"" />
<object name=""IDummy157_2"" type=""Dummies.SimpleDummy473"" singleton=""false"" />
<object name=""IDummy158_0"" type=""Dummies.SimpleDummy474"" singleton=""false"" />
<object name=""IDummy158_1"" type=""Dummies.SimpleDummy475"" singleton=""false"" />
<object name=""IDummy158_2"" type=""Dummies.SimpleDummy476"" singleton=""false"" />
<object name=""IDummy159_0"" type=""Dummies.SimpleDummy477"" singleton=""false"" />
<object name=""IDummy159_1"" type=""Dummies.SimpleDummy478"" singleton=""false"" />
<object name=""IDummy159_2"" type=""Dummies.SimpleDummy479"" singleton=""false"" />
<object name=""IDummy160_0"" type=""Dummies.SimpleDummy480"" singleton=""false"" />
<object name=""IDummy160_1"" type=""Dummies.SimpleDummy481"" singleton=""false"" />
<object name=""IDummy160_2"" type=""Dummies.SimpleDummy482"" singleton=""false"" />
<object name=""IDummy161_0"" type=""Dummies.SimpleDummy483"" singleton=""false"" />
<object name=""IDummy161_1"" type=""Dummies.SimpleDummy484"" singleton=""false"" />
<object name=""IDummy161_2"" type=""Dummies.SimpleDummy485"" singleton=""false"" />
<object name=""IDummy162_0"" type=""Dummies.SimpleDummy486"" singleton=""false"" />
<object name=""IDummy162_1"" type=""Dummies.SimpleDummy487"" singleton=""false"" />
<object name=""IDummy162_2"" type=""Dummies.SimpleDummy488"" singleton=""false"" />
<object name=""IDummy163_0"" type=""Dummies.SimpleDummy489"" singleton=""false"" />
<object name=""IDummy163_1"" type=""Dummies.SimpleDummy490"" singleton=""false"" />
<object name=""IDummy163_2"" type=""Dummies.SimpleDummy491"" singleton=""false"" />
<object name=""IDummy164_0"" type=""Dummies.SimpleDummy492"" singleton=""false"" />
<object name=""IDummy164_1"" type=""Dummies.SimpleDummy493"" singleton=""false"" />
<object name=""IDummy164_2"" type=""Dummies.SimpleDummy494"" singleton=""false"" />
<object name=""IDummy165_0"" type=""Dummies.SimpleDummy495"" singleton=""false"" />
<object name=""IDummy165_1"" type=""Dummies.SimpleDummy496"" singleton=""false"" />
<object name=""IDummy165_2"" type=""Dummies.SimpleDummy497"" singleton=""false"" />
<object name=""IDummy166_0"" type=""Dummies.SimpleDummy498"" singleton=""false"" />
<object name=""IDummy166_1"" type=""Dummies.SimpleDummy499"" singleton=""false"" />
<object name=""IDummy166_2"" type=""Dummies.SimpleDummy500"" singleton=""false"" />
<object name=""IDummy167_0"" type=""Dummies.SimpleDummy501"" singleton=""false"" />
<object name=""IDummy167_1"" type=""Dummies.SimpleDummy502"" singleton=""false"" />
<object name=""IDummy167_2"" type=""Dummies.SimpleDummy503"" singleton=""false"" />
<object name=""IDummy168_0"" type=""Dummies.SimpleDummy504"" singleton=""false"" />
<object name=""IDummy168_1"" type=""Dummies.SimpleDummy505"" singleton=""false"" />
<object name=""IDummy168_2"" type=""Dummies.SimpleDummy506"" singleton=""false"" />
<object name=""IDummy169_0"" type=""Dummies.SimpleDummy507"" singleton=""false"" />
<object name=""IDummy169_1"" type=""Dummies.SimpleDummy508"" singleton=""false"" />
<object name=""IDummy169_2"" type=""Dummies.SimpleDummy509"" singleton=""false"" />
<object name=""IDummy170_0"" type=""Dummies.SimpleDummy510"" singleton=""false"" />
<object name=""IDummy170_1"" type=""Dummies.SimpleDummy511"" singleton=""false"" />
<object name=""IDummy170_2"" type=""Dummies.SimpleDummy512"" singleton=""false"" />
<object name=""IDummy171_0"" type=""Dummies.SimpleDummy513"" singleton=""false"" />
<object name=""IDummy171_1"" type=""Dummies.SimpleDummy514"" singleton=""false"" />
<object name=""IDummy171_2"" type=""Dummies.SimpleDummy515"" singleton=""false"" />
<object name=""IDummy172_0"" type=""Dummies.SimpleDummy516"" singleton=""false"" />
<object name=""IDummy172_1"" type=""Dummies.SimpleDummy517"" singleton=""false"" />
<object name=""IDummy172_2"" type=""Dummies.SimpleDummy518"" singleton=""false"" />
<object name=""IDummy173_0"" type=""Dummies.SimpleDummy519"" singleton=""false"" />
<object name=""IDummy173_1"" type=""Dummies.SimpleDummy520"" singleton=""false"" />
<object name=""IDummy173_2"" type=""Dummies.SimpleDummy521"" singleton=""false"" />
<object name=""IDummy174_0"" type=""Dummies.SimpleDummy522"" singleton=""false"" />
<object name=""IDummy174_1"" type=""Dummies.SimpleDummy523"" singleton=""false"" />
<object name=""IDummy174_2"" type=""Dummies.SimpleDummy524"" singleton=""false"" />
<object name=""IDummy175_0"" type=""Dummies.SimpleDummy525"" singleton=""false"" />
<object name=""IDummy175_1"" type=""Dummies.SimpleDummy526"" singleton=""false"" />
<object name=""IDummy175_2"" type=""Dummies.SimpleDummy527"" singleton=""false"" />
<object name=""IDummy176_0"" type=""Dummies.SimpleDummy528"" singleton=""false"" />
<object name=""IDummy176_1"" type=""Dummies.SimpleDummy529"" singleton=""false"" />
<object name=""IDummy176_2"" type=""Dummies.SimpleDummy530"" singleton=""false"" />
<object name=""IDummy177_0"" type=""Dummies.SimpleDummy531"" singleton=""false"" />
<object name=""IDummy177_1"" type=""Dummies.SimpleDummy532"" singleton=""false"" />
<object name=""IDummy177_2"" type=""Dummies.SimpleDummy533"" singleton=""false"" />
<object name=""IDummy178_0"" type=""Dummies.SimpleDummy534"" singleton=""false"" />
<object name=""IDummy178_1"" type=""Dummies.SimpleDummy535"" singleton=""false"" />
<object name=""IDummy178_2"" type=""Dummies.SimpleDummy536"" singleton=""false"" />
<object name=""IDummy179_0"" type=""Dummies.SimpleDummy537"" singleton=""false"" />
<object name=""IDummy179_1"" type=""Dummies.SimpleDummy538"" singleton=""false"" />
<object name=""IDummy179_2"" type=""Dummies.SimpleDummy539"" singleton=""false"" />
<object name=""IDummy180_0"" type=""Dummies.SimpleDummy540"" singleton=""false"" />
<object name=""IDummy180_1"" type=""Dummies.SimpleDummy541"" singleton=""false"" />
<object name=""IDummy180_2"" type=""Dummies.SimpleDummy542"" singleton=""false"" />
<object name=""IDummy181_0"" type=""Dummies.SimpleDummy543"" singleton=""false"" />
<object name=""IDummy181_1"" type=""Dummies.SimpleDummy544"" singleton=""false"" />
<object name=""IDummy181_2"" type=""Dummies.SimpleDummy545"" singleton=""false"" />
<object name=""IDummy182_0"" type=""Dummies.SimpleDummy546"" singleton=""false"" />
<object name=""IDummy182_1"" type=""Dummies.SimpleDummy547"" singleton=""false"" />
<object name=""IDummy182_2"" type=""Dummies.SimpleDummy548"" singleton=""false"" />
<object name=""IDummy183_0"" type=""Dummies.SimpleDummy549"" singleton=""false"" />
<object name=""IDummy183_1"" type=""Dummies.SimpleDummy550"" singleton=""false"" />
<object name=""IDummy183_2"" type=""Dummies.SimpleDummy551"" singleton=""false"" />
<object name=""IDummy184_0"" type=""Dummies.SimpleDummy552"" singleton=""false"" />
<object name=""IDummy184_1"" type=""Dummies.SimpleDummy553"" singleton=""false"" />
<object name=""IDummy184_2"" type=""Dummies.SimpleDummy554"" singleton=""false"" />
<object name=""IDummy185_0"" type=""Dummies.SimpleDummy555"" singleton=""false"" />
<object name=""IDummy185_1"" type=""Dummies.SimpleDummy556"" singleton=""false"" />
<object name=""IDummy185_2"" type=""Dummies.SimpleDummy557"" singleton=""false"" />
<object name=""IDummy186_0"" type=""Dummies.SimpleDummy558"" singleton=""false"" />
<object name=""IDummy186_1"" type=""Dummies.SimpleDummy559"" singleton=""false"" />
<object name=""IDummy186_2"" type=""Dummies.SimpleDummy560"" singleton=""false"" />
<object name=""IDummy187_0"" type=""Dummies.SimpleDummy561"" singleton=""false"" />
<object name=""IDummy187_1"" type=""Dummies.SimpleDummy562"" singleton=""false"" />
<object name=""IDummy187_2"" type=""Dummies.SimpleDummy563"" singleton=""false"" />
<object name=""IDummy188_0"" type=""Dummies.SimpleDummy564"" singleton=""false"" />
<object name=""IDummy188_1"" type=""Dummies.SimpleDummy565"" singleton=""false"" />
<object name=""IDummy188_2"" type=""Dummies.SimpleDummy566"" singleton=""false"" />
<object name=""IDummy189_0"" type=""Dummies.SimpleDummy567"" singleton=""false"" />
<object name=""IDummy189_1"" type=""Dummies.SimpleDummy568"" singleton=""false"" />
<object name=""IDummy189_2"" type=""Dummies.SimpleDummy569"" singleton=""false"" />
<object name=""IDummy190_0"" type=""Dummies.SimpleDummy570"" singleton=""false"" />
<object name=""IDummy190_1"" type=""Dummies.SimpleDummy571"" singleton=""false"" />
<object name=""IDummy190_2"" type=""Dummies.SimpleDummy572"" singleton=""false"" />
<object name=""IDummy191_0"" type=""Dummies.SimpleDummy573"" singleton=""false"" />
<object name=""IDummy191_1"" type=""Dummies.SimpleDummy574"" singleton=""false"" />
<object name=""IDummy191_2"" type=""Dummies.SimpleDummy575"" singleton=""false"" />
<object name=""IDummy192_0"" type=""Dummies.SimpleDummy576"" singleton=""false"" />
<object name=""IDummy192_1"" type=""Dummies.SimpleDummy577"" singleton=""false"" />
<object name=""IDummy192_2"" type=""Dummies.SimpleDummy578"" singleton=""false"" />
<object name=""IDummy193_0"" type=""Dummies.SimpleDummy579"" singleton=""false"" />
<object name=""IDummy193_1"" type=""Dummies.SimpleDummy580"" singleton=""false"" />
<object name=""IDummy193_2"" type=""Dummies.SimpleDummy581"" singleton=""false"" />
<object name=""IDummy194_0"" type=""Dummies.SimpleDummy582"" singleton=""false"" />
<object name=""IDummy194_1"" type=""Dummies.SimpleDummy583"" singleton=""false"" />
<object name=""IDummy194_2"" type=""Dummies.SimpleDummy584"" singleton=""false"" />
<object name=""IDummy195_0"" type=""Dummies.SimpleDummy585"" singleton=""false"" />
<object name=""IDummy195_1"" type=""Dummies.SimpleDummy586"" singleton=""false"" />
<object name=""IDummy195_2"" type=""Dummies.SimpleDummy587"" singleton=""false"" />
<object name=""IDummy196_0"" type=""Dummies.SimpleDummy588"" singleton=""false"" />
<object name=""IDummy196_1"" type=""Dummies.SimpleDummy589"" singleton=""false"" />
<object name=""IDummy196_2"" type=""Dummies.SimpleDummy590"" singleton=""false"" />
<object name=""IDummy197_0"" type=""Dummies.SimpleDummy591"" singleton=""false"" />
<object name=""IDummy197_1"" type=""Dummies.SimpleDummy592"" singleton=""false"" />
<object name=""IDummy197_2"" type=""Dummies.SimpleDummy593"" singleton=""false"" />
<object name=""IDummy198_0"" type=""Dummies.SimpleDummy594"" singleton=""false"" />
<object name=""IDummy198_1"" type=""Dummies.SimpleDummy595"" singleton=""false"" />
<object name=""IDummy198_2"" type=""Dummies.SimpleDummy596"" singleton=""false"" />
<object name=""IDummy199_0"" type=""Dummies.SimpleDummy597"" singleton=""false"" />
<object name=""IDummy199_1"" type=""Dummies.SimpleDummy598"" singleton=""false"" />
<object name=""IDummy199_2"" type=""Dummies.SimpleDummy599"" singleton=""false"" />
<object name=""IDummy200_0"" type=""Dummies.SimpleDummy600"" singleton=""false"" />
<object name=""IDummy200_1"" type=""Dummies.SimpleDummy601"" singleton=""false"" />
<object name=""IDummy200_2"" type=""Dummies.SimpleDummy602"" singleton=""false"" />
<object name=""IDummy201_0"" type=""Dummies.SimpleDummy603"" singleton=""false"" />
<object name=""IDummy201_1"" type=""Dummies.SimpleDummy604"" singleton=""false"" />
<object name=""IDummy201_2"" type=""Dummies.SimpleDummy605"" singleton=""false"" />
<object name=""IDummy202_0"" type=""Dummies.SimpleDummy606"" singleton=""false"" />
<object name=""IDummy202_1"" type=""Dummies.SimpleDummy607"" singleton=""false"" />
<object name=""IDummy202_2"" type=""Dummies.SimpleDummy608"" singleton=""false"" />
<object name=""IDummy203_0"" type=""Dummies.SimpleDummy609"" singleton=""false"" />
<object name=""IDummy203_1"" type=""Dummies.SimpleDummy610"" singleton=""false"" />
<object name=""IDummy203_2"" type=""Dummies.SimpleDummy611"" singleton=""false"" />
<object name=""IDummy204_0"" type=""Dummies.SimpleDummy612"" singleton=""false"" />
<object name=""IDummy204_1"" type=""Dummies.SimpleDummy613"" singleton=""false"" />
<object name=""IDummy204_2"" type=""Dummies.SimpleDummy614"" singleton=""false"" />
<object name=""IDummy205_0"" type=""Dummies.SimpleDummy615"" singleton=""false"" />
<object name=""IDummy205_1"" type=""Dummies.SimpleDummy616"" singleton=""false"" />
<object name=""IDummy205_2"" type=""Dummies.SimpleDummy617"" singleton=""false"" />
<object name=""IDummy206_0"" type=""Dummies.SimpleDummy618"" singleton=""false"" />
<object name=""IDummy206_1"" type=""Dummies.SimpleDummy619"" singleton=""false"" />
<object name=""IDummy206_2"" type=""Dummies.SimpleDummy620"" singleton=""false"" />
<object name=""IDummy207_0"" type=""Dummies.SimpleDummy621"" singleton=""false"" />
<object name=""IDummy207_1"" type=""Dummies.SimpleDummy622"" singleton=""false"" />
<object name=""IDummy207_2"" type=""Dummies.SimpleDummy623"" singleton=""false"" />
<object name=""IDummy208_0"" type=""Dummies.SimpleDummy624"" singleton=""false"" />
<object name=""IDummy208_1"" type=""Dummies.SimpleDummy625"" singleton=""false"" />
<object name=""IDummy208_2"" type=""Dummies.SimpleDummy626"" singleton=""false"" />
<object name=""IDummy209_0"" type=""Dummies.SimpleDummy627"" singleton=""false"" />
<object name=""IDummy209_1"" type=""Dummies.SimpleDummy628"" singleton=""false"" />
<object name=""IDummy209_2"" type=""Dummies.SimpleDummy629"" singleton=""false"" />
<object name=""IDummy210_0"" type=""Dummies.SimpleDummy630"" singleton=""false"" />
<object name=""IDummy210_1"" type=""Dummies.SimpleDummy631"" singleton=""false"" />
<object name=""IDummy210_2"" type=""Dummies.SimpleDummy632"" singleton=""false"" />
<object name=""IDummy211_0"" type=""Dummies.SimpleDummy633"" singleton=""false"" />
<object name=""IDummy211_1"" type=""Dummies.SimpleDummy634"" singleton=""false"" />
<object name=""IDummy211_2"" type=""Dummies.SimpleDummy635"" singleton=""false"" />
<object name=""IDummy212_0"" type=""Dummies.SimpleDummy636"" singleton=""false"" />
<object name=""IDummy212_1"" type=""Dummies.SimpleDummy637"" singleton=""false"" />
<object name=""IDummy212_2"" type=""Dummies.SimpleDummy638"" singleton=""false"" />
<object name=""IDummy213_0"" type=""Dummies.SimpleDummy639"" singleton=""false"" />
<object name=""IDummy213_1"" type=""Dummies.SimpleDummy640"" singleton=""false"" />
<object name=""IDummy213_2"" type=""Dummies.SimpleDummy641"" singleton=""false"" />
<object name=""IDummy214_0"" type=""Dummies.SimpleDummy642"" singleton=""false"" />
<object name=""IDummy214_1"" type=""Dummies.SimpleDummy643"" singleton=""false"" />
<object name=""IDummy214_2"" type=""Dummies.SimpleDummy644"" singleton=""false"" />
<object name=""IDummy215_0"" type=""Dummies.SimpleDummy645"" singleton=""false"" />
<object name=""IDummy215_1"" type=""Dummies.SimpleDummy646"" singleton=""false"" />
<object name=""IDummy215_2"" type=""Dummies.SimpleDummy647"" singleton=""false"" />
<object name=""IDummy216_0"" type=""Dummies.SimpleDummy648"" singleton=""false"" />
<object name=""IDummy216_1"" type=""Dummies.SimpleDummy649"" singleton=""false"" />
<object name=""IDummy216_2"" type=""Dummies.SimpleDummy650"" singleton=""false"" />
<object name=""IDummy217_0"" type=""Dummies.SimpleDummy651"" singleton=""false"" />
<object name=""IDummy217_1"" type=""Dummies.SimpleDummy652"" singleton=""false"" />
<object name=""IDummy217_2"" type=""Dummies.SimpleDummy653"" singleton=""false"" />
<object name=""IDummy218_0"" type=""Dummies.SimpleDummy654"" singleton=""false"" />
<object name=""IDummy218_1"" type=""Dummies.SimpleDummy655"" singleton=""false"" />
<object name=""IDummy218_2"" type=""Dummies.SimpleDummy656"" singleton=""false"" />
<object name=""IDummy219_0"" type=""Dummies.SimpleDummy657"" singleton=""false"" />
<object name=""IDummy219_1"" type=""Dummies.SimpleDummy658"" singleton=""false"" />
<object name=""IDummy219_2"" type=""Dummies.SimpleDummy659"" singleton=""false"" />
<object name=""IDummy220_0"" type=""Dummies.SimpleDummy660"" singleton=""false"" />
<object name=""IDummy220_1"" type=""Dummies.SimpleDummy661"" singleton=""false"" />
<object name=""IDummy220_2"" type=""Dummies.SimpleDummy662"" singleton=""false"" />
<object name=""IDummy221_0"" type=""Dummies.SimpleDummy663"" singleton=""false"" />
<object name=""IDummy221_1"" type=""Dummies.SimpleDummy664"" singleton=""false"" />
<object name=""IDummy221_2"" type=""Dummies.SimpleDummy665"" singleton=""false"" />

</objects>";

		public string Name {
			get { return "Spring"; }
		}

		public void WarmUp_Singleton() {

			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_SINGLETON)), "config"));
			// k = new XmlApplicationContext("file://SpringConfig.xml");
			// var ctx = new GenericApplicationContext();
			// ctx.RegisterObjectDefinition
		}
		public void WarmUp_NewEveryTime() {
			k = new XmlObjectFactory(new InputStreamResource(new MemoryStream(Encoding.UTF8.GetBytes(CONFIG_TRANSIENT)), "config"));
		}
		public void WarmUp_PerThread() { }

		public void Run() { throw new NotImplementedException(); }

		public void Run(Type t, string name) {
			var typeKey = string.Format("{0}_{1}", t.Name, name);
			((IDummy) k.GetObject(typeKey)).Do();
		}
	}
}